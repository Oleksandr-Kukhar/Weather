using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core
{
    public abstract class CallibratingSensor : Sensor
    {
        public abstract double CurrentValue();
        public abstract void SetHighValue(double newValue);
        public abstract void SetLowValue(double newValue);
    }
}
