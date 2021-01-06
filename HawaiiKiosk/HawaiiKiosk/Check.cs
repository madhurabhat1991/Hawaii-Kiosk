using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Check : Payment
    {
        private long _bankNumber = 123456;
        private long _routingNumber = 123456789;
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

        public Check()
        {
        }

        public bool ValidateCheck(long bankNumber, long routingNumber)
        {
            if (bankNumber == _bankNumber && routingNumber == _routingNumber)
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
