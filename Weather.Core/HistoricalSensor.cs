using System;
using System.Collections.Generic;
using System.Text;
using Weather.Core.Domain;

namespace Weather.Core
{
    public abstract class HistoricalSensor<T>: CallibratingSensor where T : Enum
    {
        public abstract double HighValue();

        public abstract double LowValue();

        public abstract DateTime TimeOfHighValue();

        public abstract DateTime TimeOfLowValue();

    }
}
