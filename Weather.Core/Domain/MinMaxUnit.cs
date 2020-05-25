using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Domain
{
    public class MinMaxUnit
    {
        public double MinValue;
        public double MaxValue;
        public double MinSensor;
        public double MaxSensor;

        public void changeValues(double newMinValue, double newMaxValue)
        {
            MinValue = newMinValue;
            MaxValue = newMaxValue;
        }
    }
}
