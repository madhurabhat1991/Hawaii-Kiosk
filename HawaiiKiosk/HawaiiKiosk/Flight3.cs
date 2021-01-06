using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Flight3 : Flight
    {
        public Flight3()
        {
            From = "Oahu";
            To = "Kauai";
            Price = 50;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
