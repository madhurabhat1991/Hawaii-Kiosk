using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Flight1 : Flight
    {
        public Flight1()
        {
            From = "Oahu";
            To = "Maui";
            Price = 80;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
