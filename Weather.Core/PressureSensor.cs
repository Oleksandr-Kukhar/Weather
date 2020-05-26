using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;

namespace Weather.Core
{
    public class PressureSensor : TrendSensor<PressureUnit>
    {
        private IPressureStorage _pressureStorage;

        public PressureSensor(IPressureStorage storage)
        {
            _pressureStorage = storage;
        }

        public PhysicalValue<PressureUnit> CurrentPressure(MinMaxUnit minmaxPressure)
        {
            var temperature = new ValueConverter().ConvertValue(_pressureStorage.GetLastValueAsync().Result.Value, minmaxPressure.MinSensor, minmaxPressure.MaxSensor, _pressureStorage.GetMinimalPressure(), _pressureStorage.GetMaximalPressure());

            var result = new PhysicalValue<PressureUnit>(temperature, PressureUnit.Hectopascal);

            return result;
        }

        public override double CurrentValue()
        {
            throw new NotImplementedException();
        }

        public override double HighValue()
        {
            return _pressureStorage.GetMaxValueAsync(DateTime.UtcNow).Result.Value;
        }

        public override double LowValue()
        {
            return _pressureStorage.GetMinValueAsync(DateTime.UtcNow).Result.Value;
        }

        public PhysicalValue<PressureUnit> HighPressure(MinMaxUnit minmaxPressure)
        {
            var humidity = new ValueConverter().ConvertValue(HighValue(), minmaxPressure.MinSensor, minmaxPressure.MaxSensor, _pressureStorage.GetMinimalPressure(), _pressureStorage.GetMaximalPressure());
            var result = new PhysicalValue<PressureUnit>(humidity, PressureUnit.Hectopascal);
            return result;
        }

        public PhysicalValue<PressureUnit> LowPressure(MinMaxUnit minmaxPressure)
        {
            var humidity = new ValueConverter().ConvertValue(LowValue(), minmaxPressure.MinSensor, minmaxPressure.MaxSensor, _pressureStorage.GetMinimalPressure(), _pressureStorage.GetMaximalPressure());
            var result = new PhysicalValue<PressureUnit>(humidity, PressureUnit.Hectopascal);
            return result;
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

        public override void SetHighValue(double newValue)
        {
            _pressureStorage.ChangeMaximalPressure(newValue);
        }

        public override void SetLowValue(double newValue)
        {
            _pressureStorage.ChangeMinimalPressure(newValue);
        }
    }
}
