using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Domain
{
    public class PhysicalValue<T> where T : Enum
    {
        public PhysicalValue(double value, T measurementUnit)
        {
            Value = value;
            MeasurementUnit = measurementUnit;
        }

        public double Value { get; set; }
        public T MeasurementUnit { get; set; }
    }
}
