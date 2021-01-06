using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public abstract class Route
    {
        private int _quantity;
        public decimal _totalPrice;
        public string From
        {
            get;
            protected set;
        }

        public string To
        {
            get;
            protected set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice += value; }
        }

        public Route()
        {
            From = "";
            To = "";
            Price = 0.0m;
        }

        public void ReverseRoute()
        {
            string tempTo = To;
            To = From;
            From = tempTo;
        }
        public override string ToString()
        {
            return "";
        }
    }
}
