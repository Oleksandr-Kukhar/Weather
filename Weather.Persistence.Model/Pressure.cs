using System;
using System.Collections.Generic;

namespace Weather.Persistence.Model
{
    public partial class Pressure
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime RegisterTime { get; set; }
        public string MeasurementUnits { get; set; }
    }
}
