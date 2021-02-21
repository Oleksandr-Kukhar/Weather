using System.Linq;
using Weather.Persistence.Infrastructure.Storage.Interfaces;

namespace Weather.Persistence.Infrastructure.Storage
{
    public class CriticalValuesStorage : ICriticalValuesStorage
    {
        private SensorsDataBaseContext _dbContext;

        public CriticalValuesStorage(SensorsDataBaseContext context)
        {
            _dbContext = context;
        }

        protected double GetValueByName(string name)
        {
            return _dbContext.CriticalValues.SingleOrDefault(x => x.ValueName == name).Value;
        }
        protected void SetValueByName(double value, string name)
        {
            var obj = _dbContext.CriticalValues.SingleOrDefault(x => x.ValueName == name);
            obj.Value = value;
            _dbContext.SaveChanges();
        }

        public double HumidityLowValue
        {
            get => GetValueByName("MinimalHumidity");
            set => SetValueByName(value, "MinimalHumidity");
        }
        public double HumidityHighValue
        {
            get => GetValueByName("MaximalHumidity");
            set => SetValueByName(value, "MaximalHumidity");
        }
        public double PressureLowValue
        {
            get => GetValueByName("MinimalPressure");
            set => SetValueByName(value, "MinimalPressure");
        }
        public double PressureHighValue
        {
            get => GetValueByName("MaximalPressure");
            set => SetValueByName(value, "MaximalPressure");
        }
        public double TemperatureLowValue
        {
            get => GetValueByName("MinimalTemperature");
            set => SetValueByName(value, "MinimalTemperature");
        }
        public double TemperatureHighValue
        {
            get => GetValueByName("MaximalTemperature");
            set => SetValueByName(value, "MaximalTemperature");
        }
        public double WindSpeedLowValue
        {
            get => GetValueByName("MinimalWindSpeed");
            set => SetValueByName(value, "MinimalWindSpeed");
        }
        public double WindSpeedHighValue
        {
            get => GetValueByName("MaximalWindSpeed");
            set => SetValueByName(value, "MaximalWindSpeed");
        }
        //
        public double RealHumidityLowValue
        {
            get => GetValueByName("MinimalRealHumidity");
            set => SetValueByName(value, "MinimalRealHumidity");
        }
        public double RealHumidityHighValue
        {
            get => GetValueByName("MaximalRealHumidity");
            set => SetValueByName(value, "MaximalRealHumidity");
        }
        public double RealPressureLowValue
        {
            get => GetValueByName("MinimalRealPressure");
            set => SetValueByName(value, "MinimalRealPressure");
        }
        public double RealPressureHighValue
        {
            get => GetValueByName("MaximalRealPressure");
            set => SetValueByName(value, "MaximalRealPressure");
        }
        public double RealTemperatureLowValue
        {
            get => GetValueByName("MinimalRealTemperature");
            set => SetValueByName(value, "MinimalRealTemperature");
        }
        public double RealTemperatureHighValue
        {
            get => GetValueByName("MaximalRealTemperature");
            set => SetValueByName(value, "MaximalRealTemperature");
        }
        public double RealWindSpeedLowValue
        {
            get => GetValueByName("MinimalRealWindSpeed");
            set => SetValueByName(value, "MinimalRealWindSpeed");
        }
        public double RealWindSpeedHighValue
        {
            get => GetValueByName("MaximalRealWindSpeed");
            set => SetValueByName(value, "MaximalRealWindSpeed");
        }
    }
}
