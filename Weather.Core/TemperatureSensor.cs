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

        public PhysicalValue<TemperatureUnit> CurrentTemperature(MinMaxUnit minmaxTemperature)
        {
            var temperature = new ValueConverter().ConvertValue(_temperatureStorage.GetLastValueAsync().Result.Value, minmaxTemperature.MinSensor, minmaxTemperature.MaxSensor, _temperatureStorage.GetMinimalTemperature(), _temperatureStorage.GetMaximalTemperature());

            var result = new PhysicalValue<TemperatureUnit>(temperature, TemperatureUnit.Kelvin);

            return result;
        }

        public override double CurrentValue()
        {
            return _temperatureStorage.GetLastValueAsync().Result.Value;
        }

        public override double HighValue()
        {
            return _temperatureStorage.GetMaxValueAsync(DateTime.UtcNow).Result.Value;
        }

        public override double LowValue()
        {
            return _temperatureStorage.GetMinValueAsync(DateTime.UtcNow).Result.Value;
        }

        public PhysicalValue<TemperatureUnit> HighTemperature(MinMaxUnit minmaxTemperature)
        {
            var temperature = new ValueConverter().ConvertValue(HighValue(), minmaxTemperature.MinSensor, minmaxTemperature.MaxSensor, _temperatureStorage.GetMinimalTemperature(), _temperatureStorage.GetMaximalTemperature());
            var result = new PhysicalValue<TemperatureUnit>(temperature, TemperatureUnit.Kelvin);
            return result;
        }

        public PhysicalValue<TemperatureUnit> LowTemperature(MinMaxUnit minmaxTemperature)
        {
            var temperature = new ValueConverter().ConvertValue(LowValue(), minmaxTemperature.MinSensor, minmaxTemperature.MaxSensor, _temperatureStorage.GetMinimalTemperature(), _temperatureStorage.GetMaximalTemperature());
            var result = new PhysicalValue<TemperatureUnit>(temperature, TemperatureUnit.Kelvin);
            return result;
        }

        public override void SetHighValue(double newValue)
        {
            _temperatureStorage.ChangeMaximalTemperature(newValue);
        }

        public override void SetLowValue(double newValue)
        {
            _temperatureStorage.ChangeMinimalTemperature(newValue);
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
