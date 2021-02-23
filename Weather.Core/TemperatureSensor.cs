using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;
using Weather.Persistence.Infrastructure.Storage.Intefaces;
using Weather.Persistence.Infrastructure.Storage.Interfaces;

namespace Weather.Core
{
    public class TemperatureSensor : TrendSensor<TemperatureUnit>
    {
        private readonly ITemperatureStorage _temperatureStorage;
        private readonly ICriticalValuesStorage _criticalValuesStorage;

        public TemperatureSensor(ITemperatureStorage storage, ICriticalValuesStorage criticalValuesStorage)
        {
            _temperatureStorage = storage;
            _criticalValuesStorage = criticalValuesStorage;
        }

        public override double CurrentValue()
        {
            var temperature = new ValueConverter().ConvertValue(
                _temperatureStorage.GetLastValueAsync().Result.Value,
                _criticalValuesStorage.TemperatureLowValue,
                _criticalValuesStorage.TemperatureHighValue,
                _criticalValuesStorage.RealTemperatureLowValue,
                _criticalValuesStorage.RealTemperatureHighValue);

            var result = new PhysicalValue<TemperatureUnit>(temperature, TemperatureUnit.Kelvin);

            return result.Value;
        }

        public override double HighValue()
        {
            var temperature = new ValueConverter().ConvertValue(
                _temperatureStorage.GetMaximalTemperature(),
                _criticalValuesStorage.TemperatureLowValue,
                _criticalValuesStorage.TemperatureHighValue,
                _criticalValuesStorage.RealTemperatureLowValue,
                _criticalValuesStorage.RealTemperatureHighValue);

            var result = new PhysicalValue<TemperatureUnit>(temperature, TemperatureUnit.Kelvin);

            return result.Value;
        }

        public override double LowValue()
        {
            var temperature = new ValueConverter().ConvertValue(
                _temperatureStorage.GetMinimalTemperature(),
                _criticalValuesStorage.TemperatureLowValue,
                _criticalValuesStorage.TemperatureHighValue,
                _criticalValuesStorage.RealTemperatureLowValue,
                _criticalValuesStorage.RealTemperatureHighValue);

            var result = new PhysicalValue<TemperatureUnit>(temperature, TemperatureUnit.Kelvin);

            return result.Value;
        }

        public override void SetRealHighValue(double newValue)
        {
            _criticalValuesStorage.RealTemperatureHighValue = newValue;
        }

        public override void SetRealLowValue(double newValue)
        {
            _criticalValuesStorage.RealTemperatureLowValue = newValue;
        }

        public override double GetRealHightValue()
        {
            return _criticalValuesStorage.RealTemperatureHighValue;
        }

        public override double GetRealLowValue()
        {
            return _criticalValuesStorage.RealTemperatureLowValue;
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
        public override void SetHighValue(double newValue)
        {
            _criticalValuesStorage.TemperatureHighValue = newValue;
        }

        public override void SetLowValue(double newValue)
        {
            _criticalValuesStorage.TemperatureLowValue = newValue;
        }

    }
}
