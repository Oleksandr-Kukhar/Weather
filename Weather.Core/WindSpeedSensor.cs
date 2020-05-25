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

        public PhysicalValue<SpeedUnit> CurrentSpeed(MinMaxUnit minmaxTemperature)
        {
            var temperature = new ValueConverter().ConvertValue(_windStorage.GetLastValueAsync().Result.Speed, minmaxTemperature.MinSensor, minmaxTemperature.MaxSensor, _windStorage.GetMinimalWindSpeed(), _windStorage.GetMaximalWindSpeed());

            var result = new PhysicalValue<SpeedUnit>(temperature, SpeedUnit.MetersPerSecond);

            return result;
        }

        public override double CurrentValue()
        {
            throw new NotImplementedException();
        }

        public override double HighValue()
        {
            return _windStorage.GetMaxValueAsync(DateTime.UtcNow).Result.Speed;
        }

        public override double LowValue()
        {
            return _windStorage.GetMinValueAsync(DateTime.UtcNow).Result.Speed;
        }

        public PhysicalValue<SpeedUnit> HighSpeed(MinMaxUnit minmaxTemperature)
        {
            var humidity = new ValueConverter().ConvertValue(HighValue(), minmaxTemperature.MinSensor, minmaxTemperature.MaxSensor, _windStorage.GetMinimalWindSpeed(), _windStorage.GetMaximalWindSpeed());
            var result = new PhysicalValue<SpeedUnit>(humidity, SpeedUnit.MetersPerSecond);
            return result;
        }

        public PhysicalValue<SpeedUnit> LowSpeed(MinMaxUnit minmaxTemperature)
        {
            var humidity = new ValueConverter().ConvertValue(LowValue(), minmaxTemperature.MinSensor, minmaxTemperature.MaxSensor, _windStorage.GetMinimalWindSpeed(), _windStorage.GetMaximalWindSpeed());
            var result = new PhysicalValue<SpeedUnit>(humidity, SpeedUnit.MetersPerSecond);
            return result;
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

        public override void SetHighValue(double newValue)
        {
            _windStorage.ChangeMaximalWindSpeed(newValue);
        }

        public override void SetLowValue(double newValue)
        {
            _windStorage.ChangeMinimalWindSpeed(newValue);
        }
    }
}
