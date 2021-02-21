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
    public class WindSpeedSensor : HistoricalSensor<SpeedUnit>
    {
        private readonly IWindStorage _windStorage;
        private readonly ICriticalValuesStorage _criticalValuesStorage;

        public WindSpeedSensor(IWindStorage storage, ICriticalValuesStorage criticalValuesStorage)
        {
            _windStorage = storage;
            _criticalValuesStorage = criticalValuesStorage;
        }

        public override double CurrentValue()
        {
            var temperature = new ValueConverter().ConvertValue(
                _windStorage.GetLastValueAsync().Result.Speed,
                _criticalValuesStorage.WindSpeedLowValue,
                _criticalValuesStorage.WindSpeedHighValue,
                _criticalValuesStorage.RealWindSpeedLowValue,
                _criticalValuesStorage.RealWindSpeedHighValue);

            var result = new PhysicalValue<SpeedUnit>(temperature, SpeedUnit.MetersPerSecond);

            return result.Value;
        }

        public override double HighValue()
        {
            var humidity = new ValueConverter().ConvertValue(
                _windStorage.GetMaximalWindSpeed(),
                _criticalValuesStorage.WindSpeedLowValue,
                _criticalValuesStorage.WindSpeedHighValue,
                _criticalValuesStorage.RealWindSpeedLowValue,
                _criticalValuesStorage.RealWindSpeedHighValue);

            var result = new PhysicalValue<SpeedUnit>(humidity, SpeedUnit.MetersPerSecond);

            return result.Value;
        }

        public override double LowValue()
        {
            var humidity = new ValueConverter().ConvertValue(
                _windStorage.GetMinimalWindSpeed(),
                _criticalValuesStorage.WindSpeedLowValue,
                _criticalValuesStorage.WindSpeedHighValue,
                _criticalValuesStorage.RealWindSpeedLowValue,
                _criticalValuesStorage.RealWindSpeedHighValue);

            var result = new PhysicalValue<SpeedUnit>(humidity, SpeedUnit.MetersPerSecond);

            return result.Value;
        }

        public override DateTime TimeOfHighValue()
        {
            var maxValTime = _windStorage.GetMaxValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return maxValTime;
        }

        public override DateTime TimeOfLowValue()
        {
            var minValTime = _windStorage.GetMinValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return minValTime;
        }

        public override void SetRealHighValue(double newValue)
        {
            _criticalValuesStorage.RealWindSpeedHighValue = newValue;
        }

        public override void SetRealLowValue(double newValue)
        {
            _criticalValuesStorage.RealWindSpeedLowValue = newValue;
        }

        public override double GetRealHightValue()
        {
            return _criticalValuesStorage.RealWindSpeedHighValue;
        }

        public override double GetRealLowValue()
        {
            return _criticalValuesStorage.RealWindSpeedLowValue;
        }
        public override void SetHighValue(double newValue)
        {
            _criticalValuesStorage.WindSpeedHighValue = newValue;
        }

        public override void SetLowValue(double newValue)
        {
            _criticalValuesStorage.WindSpeedLowValue = newValue;
        }
    }
}
