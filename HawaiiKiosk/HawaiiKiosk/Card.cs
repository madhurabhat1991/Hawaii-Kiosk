using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Card : Payment
    {
        private long _creditCardNumber = 1234567891234567;
        private int _expirationDate = 1221;
        private int _ccv = 123;
        public static decimal _amount = 500m;

        public override decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (_amount < 0)
                {
                    throw new ArgumentException($"The amount is less than 0. Payment declined!");
                }
                _amount = value;
            }
        }

        public Card()
        {
        }

        public bool ValidateCard(long creditCardNumber, int expirationDate, int ccv)
        {
            if (creditCardNumber == _creditCardNumber && expirationDate == _expirationDate && ccv == _ccv)
            {
                return true;
            }
            return false;
        }

        public void Debit(decimal amount)
        {
            if (amount > Amount)
            {
                throw new ArgumentException($"The cost {amount:C} is greater than your account balance {Amount:C}. Payment declined!");
            }
            Amount -= amount;
        }
    }
}
