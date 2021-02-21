using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core
{
    public abstract class CallibratingSensor : Sensor
    {
        public abstract double CurrentValue();
        public abstract void SetRealHighValue(double newValue);
        public abstract void SetRealLowValue(double newValue);
        public abstract double GetRealHightValue();
        public abstract double GetRealLowValue();
        public abstract void SetHighValue(double newValue);
        public abstract void SetLowValue(double newValue);
    }
}
