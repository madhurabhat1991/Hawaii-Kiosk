using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Ferry2 : Ferry
    {
        public Ferry2()
        {
            From = "Maui";
            To = "Molokai";
            Price = 40;
            ChildPrice = 20;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
