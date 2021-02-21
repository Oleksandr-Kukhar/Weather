using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;
using Weather.Persistence.Infrastructure.Storage.Intefaces;

namespace Weather.Core
{
    public class HumiditySensor : HistoricalSensor<HumidityUnit>
    {
        private IHumidityStorage _humidityStorage;

        public HumiditySensor(IHumidityStorage storage)
        {
            _humidityStorage = storage;
        }

        public PhysicalValue<HumidityUnit> CurrentHumidity(MinMaxUnit minmaxHumidity)
        {
            var temperature = new ValueConverter().ConvertValue(_humidityStorage.GetLastValueAsync().Result.Value, minmaxHumidity.MinSensor, minmaxHumidity.MaxSensor, _humidityStorage.GetMinimalHumidity(), _humidityStorage.GetMaximalHumidity());

            var result = new PhysicalValue<HumidityUnit>(temperature, HumidityUnit.Percent);

            return result;
        }

        public override double CurrentValue()
        {
            throw new NotImplementedException();
        }

        public override double HighValue()
        {
            return _humidityStorage.GetMaxValueAsync(DateTime.UtcNow).Result.Value;
        }

        public override double LowValue()
        {
            return _humidityStorage.GetMinValueAsync(DateTime.UtcNow).Result.Value;
        }

        public PhysicalValue<HumidityUnit> HighHumidity(MinMaxUnit minmaxHumidity)
        {
            var humidity = new ValueConverter().ConvertValue(HighValue(), minmaxHumidity.MinSensor, minmaxHumidity.MaxSensor, _humidityStorage.GetMinimalHumidity(), _humidityStorage.GetMaximalHumidity());
            var result = new PhysicalValue<HumidityUnit>(humidity, HumidityUnit.Percent);
            return result;
        }

        public PhysicalValue<HumidityUnit> LowHumidity(MinMaxUnit minmaxHumidity)
        {
            var humidity = new ValueConverter().ConvertValue(LowValue(), minmaxHumidity.MinSensor, minmaxHumidity.MaxSensor, _humidityStorage.GetMinimalHumidity(), _humidityStorage.GetMaximalHumidity());
            var result = new PhysicalValue<HumidityUnit>(humidity, HumidityUnit.Percent);
            return result;
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

        public override void SetHighValue(double newValue)
        {
            _humidityStorage.ChangeMaximalHumidity(newValue);
        }

        public override void SetLowValue(double newValue)
        {
            _humidityStorage.ChangeMinimalHumidity(newValue);
        }
    }
}
