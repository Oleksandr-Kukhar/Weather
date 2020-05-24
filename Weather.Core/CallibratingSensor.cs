using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core
{
    public abstract class CallibratingSensor : Sensor
    {
        public abstract double CurrentValue();
        public abstract void SetHighValue();
        public abstract void SetLowValue();
    }
}
