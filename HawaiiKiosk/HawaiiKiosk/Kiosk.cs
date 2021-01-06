using System;
using System.Collections.Generic;

namespace HawaiiKiosk
{
    public class Kiosk
    {
        static void Main(string[] args)
        {
            var _screen = new Screen();
            var _keypad = new Keypad();

            _screen.WriteLine("In this Kiosk, you will be travelling between Hawaiian Islands.");
            _screen.WriteLine("You will only be entering numerical values (from 0 to a certain number).\n");

            SelectRoute(_screen, _keypad);
        }

        public static List<string> _routeList = new List<string>();
        public static decimal _totalAmount = 0;

        static void SelectRoute(Screen screen, Keypad keypad)
        {
            screen.WriteLine("Let's add a route, so enter a number that corresponds to one of the following routes:");
            Route[] routes = new Route[]
            {
                new Ferry1(),
                new Ferry2(),
                new Flight1(),
                new Flight2(),
                new Flight3()
            };

            for (int i = 0; i < routes.Length; ++i)
            {
                screen.WriteLine($"  {i + 1}. {routes[i].ToString()}");
            }

            int choice = routes.Length + 1;


            while (choice > routes.Length)
            {
                choice = ValidateIntInput(screen, keypad, 1);

                if (choice <= routes.Length)
                {
                    Route route = routes[choice - 1];

                    //Select To or From
                    screen.WriteLine($"Enter 1 if you want to go from {route.From} to {route.To}; " +
                        $"Any other number if you want to go from {route.To} to {route.From}");
                    int choice2 = ValidateIntInput(screen, keypad, 1);

                    if (choice2 != 1)    //Reverse the route
                    {
                        route.ReverseRoute();
                    }

                    decimal tempPrice;

                    //Get Child price if using Ferry
                    if (route is Ferry)
                    {
                        screen.WriteLine($"Enter 1 if the passenger is child; Any other number if an adult");
                        int choice3 = ValidateIntInput(screen, keypad, 1);

                        if (choice3 == 1)
                        {
                            var tempFerry = (Ferry)route;
                            tempPrice = tempFerry.ChildPrice;
                        }
                        else
                        {
                            tempPrice = route.Price;
                        }
                        route.Price = tempPrice;
                    }

                    screen.WriteLine($"Enter the number of people travelling");
                    route.Quantity = (int)keypad.ReadValue();

                    route.TotalPrice = route.Price * route.Quantity;
                    _totalAmount += route.TotalPrice;

                    string tempPrint = $"{route.GetType().BaseType.Name} goes from {route.From} to {route.To} for {route.Quantity} X {route.Price:C} = {route.TotalPrice:C}";
                    _routeList.Add(tempPrint);

                    screen.WriteLine($"\nRoute Summary - {tempPrint}");

                    Print(screen);

                    screen.WriteLine($"Total Cost of this transaction: {_totalAmount:C}");

                    SelectPayment(screen, keypad, _totalAmount);
                }
                else
                {
                    screen.WriteLine($"Please choose from 1 through {routes.Length}");
                }

            }

            screen.WriteLine("");

        }

        public static void SelectPayment(Screen screen, Keypad keypad, decimal totalAmount)
        {
            screen.WriteLine("\nEnter 1 to pay; Any other number to continue entering new routes.");
            int choice = ValidateIntInput(screen, keypad, 1);

            if (choice != 1)
            {
                SelectRoute(screen, keypad);
            }
            else
            {
                screen.WriteLine("\nSelect a payment option:");
                List<Payment> payments = new List<Payment>()
                {
                    new Check(),
                    new Card()
                };

                for (int i = 0; i < payments.Count; ++i)
                {
                    screen.WriteLine($"  {i + 1}. {payments[i].GetType().Name}");
                }

                int choice2 = payments.Count + 1;


                while (choice2 > payments.Count)
                {
                    choice2 = ValidateIntInput(screen, keypad, 1);

                    if (choice2 <= payments.Count)
                    {
                        Payment payment = payments[choice2 - 1];

                        if (payment is Check)
                        {
                            screen.WriteLine("Enter your 6-digit bank number (123456)");
                            long bankNum = ValidateLongInput(screen, keypad, 6);
                            screen.WriteLine("Enter your 9-digit routing number (123456789)");
                            long routingNum = ValidateLongInput(screen, keypad, 9);

                            var currentCheck = (Check)payment;

                            if (currentCheck.ValidateCheck(bankNum, routingNum))
                            {
                                try
                                {
                                    currentCheck.Debit(totalAmount);
                                    screen.WriteLine($"\nYour Check account is left with {currentCheck.Amount:C}");
                                    _routeList.Clear();
                                    _totalAmount = 0;
                                    screen.WriteLine($"Transaction is reset\n");
                                    SelectRoute(screen, keypad);
                                }
                                catch (Exception ex)
                                {
                                    screen.WriteLine(ex.Message);
                                    SelectPayment(screen, keypad, totalAmount);
                                }
                            }
                            else
                            {
                                screen.WriteLine("Bank number and Routing number doesn't match");
                                SelectPayment(screen, keypad, totalAmount);
                            }
                        }
                        else if (payment is Card)
                        {
                            screen.WriteLine("Enter your 16-digit Credit card number (1234567891234567)");
                            long cardNum = ValidateLongInput(screen, keypad, 16);
                            screen.WriteLine("Enter your 4-digit Expiration date (1221)");
                            int date = ValidateIntInput(screen, keypad, 4);
                            screen.WriteLine("Enter your 3-digit CCV (123)");
                            int ccv = ValidateIntInput(screen, keypad, 3);

                            var currentCard = (Card)payment;

                            if (currentCard.ValidateCard(cardNum, date, ccv))
                            {
                                try
                                {
                                    currentCard.Debit(totalAmount);
                                    screen.WriteLine($"\nYour Card account is left with {currentCard.Amount:C}");
                                    _routeList.Clear();
                                    _totalAmount = 0;
                                    screen.WriteLine($"Transaction is reset\n");
                                    SelectRoute(screen, keypad);
                                }
                                catch (Exception ex)
                                {
                                    screen.WriteLine(ex.Message);
                                    SelectPayment(screen, keypad, totalAmount);
                                }
                            }
                            else
                            {
                                screen.WriteLine("Credit Card number, Expiration Date and CCV doesn't match");
                                SelectPayment(screen, keypad, totalAmount);
                            }
                        }

                    }
                    else
                    {
                        screen.WriteLine($"Please choose from 1 through {payments.Count}");
                    }

                }
            }
        }

        static int ValidateIntInput(Screen screen, Keypad keypad, int numberOfDigits)
        {
            long num = 0;
            for (; ; )
            {
                try
                {
                    num = keypad.ReadValue(numberOfDigits);
                    break;
                }
                catch (Exception ex)
                {
                    screen.WriteLine(ex.Message);
                }
            }
            int numInt = (int)num;
            return numInt;
        }

        static long ValidateLongInput(Screen screen, Keypad keypad, int numberOfDigits)
        {
            long num = 0;
            for (; ; )
            {
                try
                {
                    num = keypad.ReadValue(numberOfDigits);
                    break;
                }
                catch (Exception ex)
                {
                    screen.WriteLine(ex.Message);
                }
            }
            return num;
        }

        static void Print(Screen screen)
        {
            screen.WriteLine("\nYour Routes:");
            foreach (var line in _routeList)
            {
                screen.WriteLine($"  *  {line}");
            }
            screen.WriteLine("");
        }
    }
}
