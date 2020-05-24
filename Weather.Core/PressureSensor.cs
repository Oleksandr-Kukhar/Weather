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

        public PhysicalValue<PressureUnit> CurrentPressure()
        {
            var pressure = new PhysicalValue<PressureUnit>(_pressureStorage.GetLastValueAsync().Result.Value, PressureUnit.Hectopascal);

            return pressure;
        }

        public override double CurrentValue()
        {
            throw new NotImplementedException();
        }

        public override PhysicalValue<PressureUnit> HighValue()
        {
            var maxPressure = _pressureStorage.GetMaxValueAsync(DateTime.UtcNow).Result;
            var pressure = new PhysicalValue<PressureUnit>(maxPressure.Value, PressureUnit.Hectopascal);
            return pressure;
        }

        public override PhysicalValue<PressureUnit> LowValue()
        {
            var minPressure = _pressureStorage.GetMinValueAsync(DateTime.UtcNow).Result;
            var pressure = new PhysicalValue<PressureUnit>(minPressure.Value, PressureUnit.Hectopascal);
            return pressure;
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
    }
}
