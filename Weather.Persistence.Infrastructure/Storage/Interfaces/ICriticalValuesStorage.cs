using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Persistence.Infrastructure.Storage.Interfaces
{
    public interface ICriticalValuesStorage
    {

        public double HumidityLowValue { get; set; }
        public double HumidityHighValue { get; set; }
        public double PressureLowValue { get; set; }
        public double PressureHighValue { get; set; }
        public double TemperatureLowValue { get; set; }
        public double TemperatureHighValue { get; set; }
        public double WindSpeedLowValue { get; set; }
        public double WindSpeedHighValue { get; set; }
        public double RealHumidityLowValue { get; set; }
        public double RealHumidityHighValue { get; set; }
        public double RealPressureLowValue { get; set; }
        public double RealPressureHighValue { get; set; }
        public double RealTemperatureLowValue { get; set; }
        public double RealTemperatureHighValue { get; set; }
        public double RealWindSpeedLowValue { get; set; }
        public double RealWindSpeedHighValue { get; set; }

    }
}
