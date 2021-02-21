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
    public class HumiditySensor : HistoricalSensor<HumidityUnit>
    {
        private readonly IHumidityStorage _humidityStorage;
        private readonly ICriticalValuesStorage _criticalValuesStorage;

        public HumiditySensor(IHumidityStorage storage, ICriticalValuesStorage criticalValuesStorage)
        {
            _humidityStorage = storage;
            _criticalValuesStorage = criticalValuesStorage;
        }

        public override double CurrentValue()
        {
            var temperature = new ValueConverter().ConvertValue(
                   _humidityStorage.GetLastValueAsync().Result.Value,
                   _criticalValuesStorage.HumidityLowValue,
                   _criticalValuesStorage.HumidityHighValue,
                   _criticalValuesStorage.RealHumidityLowValue,
                   _criticalValuesStorage.RealHumidityHighValue);

            var result = new PhysicalValue<HumidityUnit>(temperature, HumidityUnit.Percent);

            return result.Value;
        }

        public override double HighValue()
        {
            var humidity = new ValueConverter().ConvertValue(
                _humidityStorage.GetMaximalHumidity(),
                _criticalValuesStorage.HumidityLowValue,
                _criticalValuesStorage.HumidityHighValue,
                _criticalValuesStorage.RealHumidityLowValue,
                _criticalValuesStorage.RealHumidityHighValue);

            var result = new PhysicalValue<HumidityUnit>(humidity, HumidityUnit.Percent);

            return result.Value;
        }

        public override double LowValue()
        {
            var humidity = new ValueConverter().ConvertValue(
                _humidityStorage.GetMinimalHumidity(),
                _criticalValuesStorage.HumidityLowValue,
                _criticalValuesStorage.HumidityHighValue,
                _criticalValuesStorage.RealHumidityLowValue,
                _criticalValuesStorage.RealHumidityHighValue);

            var result = new PhysicalValue<HumidityUnit>(humidity, HumidityUnit.Percent);

            return result.Value;
        }

        public override DateTime TimeOfHighValue()
        {
            var maxValTime = _humidityStorage.GetMaxValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return maxValTime;
        }

        public override DateTime TimeOfLowValue()
        {
            var minValTime = _humidityStorage.GetMinValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return minValTime;
        }

        public override void SetRealHighValue(double newValue)
        {
            _criticalValuesStorage.RealHumidityHighValue = newValue;
        }

        public override void SetRealLowValue(double newValue)
        {
            _criticalValuesStorage.RealHumidityLowValue = newValue;
        }

        public override double GetRealHightValue()
        {
            return _criticalValuesStorage.RealHumidityHighValue;
        }

        public override double GetRealLowValue()
        {
            return _criticalValuesStorage.RealHumidityLowValue;
        }

        public override void SetHighValue(double newValue)
        {
            _criticalValuesStorage.HumidityHighValue = newValue;
        }

        public override void SetLowValue(double newValue)
        {
            _criticalValuesStorage.HumidityLowValue = newValue;
        }
    }
}
