using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;

namespace Weather.Core
{
    public class HumiditySensor : HistoricalSensor<HumidityUnit>
    {
        private IHumidityStorage _humidityStorage;

        public HumiditySensor(IHumidityStorage storage)
        {
            _humidityStorage = storage;
        }

        public PhysicalValue<HumidityUnit> CurrentHumidity()
        {
            var humidity = new PhysicalValue<HumidityUnit>(_humidityStorage.GetLastValueAsync().Result.Value, HumidityUnit.Percent);
            return humidity;
        }

        public override double CurrentValue()
        {
            throw new NotImplementedException();
        }

        public override PhysicalValue<HumidityUnit> HighValue()
        {
            var maxHumidity = _humidityStorage.GetMaxValueAsync(DateTime.UtcNow).Result;
            var humidity = new PhysicalValue<HumidityUnit>(maxHumidity.Value, HumidityUnit.Percent);
            return humidity;
        }

        public override PhysicalValue<HumidityUnit> LowValue()
        {
            var minHumidity = _humidityStorage.GetMinValueAsync(DateTime.UtcNow).Result;
            var humidity = new PhysicalValue<HumidityUnit>(minHumidity.Value, HumidityUnit.Percent);
            return humidity;
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
            var maxValTime = _humidityStorage.GetMaxValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return maxValTime;
        }

        public override DateTime TimeOfLowValue()
        {
            var minValTime = _humidityStorage.GetMinValueAsync(DateTime.UtcNow).Result.RegisterTime;
            return minValTime;
        }
    }
}
