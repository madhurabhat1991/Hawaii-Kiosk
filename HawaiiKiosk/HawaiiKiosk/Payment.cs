using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public abstract class Payment
    {

        public abstract decimal Amount
        {
            get; set;
        }

        public Payment()
        {
        }
    }
}
