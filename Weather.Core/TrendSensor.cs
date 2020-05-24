using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core
{
    public abstract class TrendSensor<T> : HistoricalSensor<T> where T: Enum
    {
        public abstract double Trend();

    }
}
