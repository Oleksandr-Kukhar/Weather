using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Domain
{
    public class ValueConverter
    {
        public double ConvertValue(double valueA, double valueAMin, double valueAMax, double valueBMin, double valueBMax)
        {
            return (valueA - valueAMin) * (valueBMax - valueBMin) / (valueAMax - valueAMin) + valueBMin;
        }
    }
}
