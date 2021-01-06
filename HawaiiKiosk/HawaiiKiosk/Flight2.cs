using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Flight2 : Flight
    {
        public Flight2()
        {
            From = "Oahu";
            To = "Kona";
            Price = 100;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
