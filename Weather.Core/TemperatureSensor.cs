using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;

namespace Weather.Core
{
    public class TemperatureSensor : TrendSensor<TemperatureUnit>
    {
        private readonly ITemperatureStorage _temperatureStorage;

        public TemperatureSensor(ITemperatureStorage storage)
        {
            _temperatureStorage = storage;
        }

        public PhysicalValue<TemperatureUnit> CurrentTemperature()
        {
            double tempMin = 5;
            double tempMax = 15;

            double sensorMin = LowValue().Value;
            double sensorMax = HighValue().Value;
            double curVal = CurrentValue();

            var result = (curVal - sensorMin) * (tempMax - tempMin) / (sensorMax - sensorMin) + tempMin;
            var result2 = (result - tempMin) * (sensorMax - sensorMin) / (tempMax - tempMin) + sensorMin;

            var temperature = new PhysicalValue<TemperatureUnit>(_temperatureStorage.GetLastValueAsync().Result.Value, TemperatureUnit.Kelvin);

            return temperature;
        }

        public override double CurrentValue()
        {
            return _temperatureStorage.GetLastValueAsync().Result.Value;
        }

        public override PhysicalValue<TemperatureUnit> HighValue()
        {
            var maxTemperature = _temperatureStorage.GetMaxValueAsync(DateTime.UtcNow).Result;
            var temperature = new PhysicalValue<TemperatureUnit>(maxTemperature.Value, TemperatureUnit.Kelvin);
            return temperature;
        }

        public override PhysicalValue<TemperatureUnit> LowValue()
        {
            var minTemperature = _temperatureStorage.GetMinValueAsync(DateTime.UtcNow).Result;
            var temperature = new PhysicalValue<TemperatureUnit>(minTemperature.Value, TemperatureUnit.Kelvin);
            return temperature;
        }

        public override void SetHighValue()
        {
            throw new NotImplementedException();
        }

        public override void SetLowValue()
        {
            throw new NotImplementedException();
        }

        public override DateTime TimeOfHighValue()
        {
            var maxTemperatureTime = _temperatureStorage.GetMaxValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return maxTemperatureTime;
        }

        public override DateTime TimeOfLowValue()
        {
            var minTemperatureTime = _temperatureStorage.GetMinValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return minTemperatureTime;
        }

        public override double Trend()
        {
            throw new NotImplementedException();
        }
    }
}
