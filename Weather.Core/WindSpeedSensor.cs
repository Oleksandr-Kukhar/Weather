using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;

namespace Weather.Core
{
    public class WindSpeedSensor : HistoricalSensor<SpeedUnit>
    {
        private IWindStorage _windStorage;

        public WindSpeedSensor(IWindStorage storage)
        {
            _windStorage = storage;
        }

        public PhysicalValue<SpeedUnit> CurrentSpeed()
        {
            var speed = new PhysicalValue<SpeedUnit>(_windStorage.GetLastValueAsync().Result.Speed, SpeedUnit.MetersPerSecond);
            return speed;
        }

        public override double CurrentValue()
        {
            throw new NotImplementedException();
        }

        public override PhysicalValue<SpeedUnit> HighValue()
        {
            var maxWind = _windStorage.GetMaxValueAsync(DateTime.UtcNow).Result;
            var speed = new PhysicalValue<SpeedUnit>(maxWind.Speed, SpeedUnit.MetersPerSecond);
            return speed;
        }

        public override PhysicalValue<SpeedUnit> LowValue()
        {
            var minWind = _windStorage.GetMinValueAsync(DateTime.UtcNow).Result;
            var speed = new PhysicalValue<SpeedUnit>(minWind.Speed, SpeedUnit.MetersPerSecond);
            return speed;
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
            var maxValTime = _windStorage.GetMaxValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return maxValTime;
        }

        public override DateTime TimeOfLowValue()
        {
            var minValTime = _windStorage.GetMinValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return minValTime;
        }
    }
}
