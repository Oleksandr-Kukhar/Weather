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
    public class PressureSensor : TrendSensor<PressureUnit>
    {
        private readonly IPressureStorage _pressureStorage;
        private readonly ICriticalValuesStorage _criticalValuesStorage;

        public PressureSensor(IPressureStorage storage, ICriticalValuesStorage criticalValuesStorage)
        {
            _pressureStorage = storage;
            _criticalValuesStorage = criticalValuesStorage;
        }

        public override double CurrentValue()
        {
            var temperature = new ValueConverter().ConvertValue(
                _pressureStorage.GetLastValueAsync().Result.Value,
                _criticalValuesStorage.PressureLowValue,
                _criticalValuesStorage.PressureHighValue,
                _criticalValuesStorage.RealPressureLowValue,
                _criticalValuesStorage.RealPressureHighValue);

            var result = new PhysicalValue<PressureUnit>(temperature, PressureUnit.Hectopascal);

            return result.Value;
        }

        public override double HighValue()
        {
            var humidity = new ValueConverter().ConvertValue(
                _pressureStorage.GetMaximalPressure(),
                _criticalValuesStorage.PressureLowValue,
                _criticalValuesStorage.PressureHighValue,
                _criticalValuesStorage.RealPressureLowValue,
                _criticalValuesStorage.RealPressureHighValue);

            var result = new PhysicalValue<PressureUnit>(humidity, PressureUnit.Hectopascal);

            return result.Value;
        }

        public override double LowValue()
        {
            var humidity = new ValueConverter().ConvertValue(
                _pressureStorage.GetMaximalPressure(),
                _criticalValuesStorage.PressureLowValue,
                _criticalValuesStorage.PressureHighValue,
                _criticalValuesStorage.RealPressureLowValue,
                _criticalValuesStorage.RealPressureHighValue);

            var result = new PhysicalValue<PressureUnit>(humidity, PressureUnit.Hectopascal);

            return result.Value;
        }

        public override DateTime TimeOfHighValue()
        {
            var maxValTime = _pressureStorage.GetMaxValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return maxValTime;
        }

        public override DateTime TimeOfLowValue()
        {
            var minValTime = _pressureStorage.GetMinValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return minValTime;
        }

        public override double Trend()
        {
            throw new NotImplementedException();
        }

        public override void SetRealHighValue(double newValue)
        {
            _criticalValuesStorage.RealPressureHighValue = newValue;
        }

        public override void SetRealLowValue(double newValue)
        {
            _criticalValuesStorage.RealPressureLowValue = newValue;
        }

        public override double GetRealHightValue()
        {
            return _criticalValuesStorage.RealPressureHighValue;
        }

        public override double GetRealLowValue()
        {
            return _criticalValuesStorage.RealPressureLowValue;
        }
        public override void SetHighValue(double newValue)
        {
            _criticalValuesStorage.PressureHighValue = newValue;
        }

        public override void SetLowValue(double newValue)
        {
            _criticalValuesStorage.PressureLowValue = newValue;
        }
    }
}
