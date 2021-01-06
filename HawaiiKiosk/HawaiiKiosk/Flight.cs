using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public abstract class Flight : Route
    {
        public Flight()
        {
        }

        public override string ToString()
        {
            return string.Format($"Flight goes from {From} to {To} or viceversa for {Price:C}");
        }
    }
}
