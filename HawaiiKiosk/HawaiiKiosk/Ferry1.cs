using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Ferry1 : Ferry
    {
        public Ferry1()
        {
            From = "Maui";
            To = "Lanai";
            Price = 30;
            ChildPrice = 20;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
