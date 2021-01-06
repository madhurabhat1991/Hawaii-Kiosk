using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public abstract class Ferry : Route
    {
        public bool IsChild { get; set; }

        public decimal ChildPrice
        {
            get;
            protected set;
        }

        public Ferry()
        {
        }

        public override string ToString()
        {
            return string.Format($"Ferry goes from {From} to {To} or viceversa for {Price:C} (Adult) {ChildPrice:C} (Child)");
        }
    }
}
