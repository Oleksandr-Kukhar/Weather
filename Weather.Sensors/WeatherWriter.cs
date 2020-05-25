using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Model;

namespace Weather.Sensors
{
    public class WeatherWriter
    {
        private SensorsDataBaseContext _dbcontext;

        public WeatherWriter(SensorsDataBaseContext context)
        {
            _dbcontext = context;
        }


        public async Task WriteIndicatorsAsync(Indicator data, MinMaxUnit t, MinMaxUnit p, MinMaxUnit s, MinMaxUnit h)
        {
            var temperature = new Temperature()
            {
                Id = Guid.NewGuid(),
                Value = new ValueConverter().ConvertValue(data.main.Temperature,t.MinValue,t.MaxValue,t.MinSensor,t.MaxSensor),
                RegisterTime = DateTime.UtcNow
            };

            var pressure = new Pressure()
            {
                Id = Guid.NewGuid(),
                Value = new ValueConverter().ConvertValue(data.main.Pressure, p.MinValue, p.MaxValue, p.MinSensor, p.MaxSensor),
                RegisterTime = DateTime.UtcNow
            };

            var humidity = new Humidity()
            {
                Id = Guid.NewGuid(),
                Value = new ValueConverter().ConvertValue(data.main.Humidity, h.MinValue, h.MaxValue, h.MinSensor, h.MaxSensor),
                RegisterTime = DateTime.UtcNow
            };

            var wind = new Persistence.Model.Wind()
            {
                Id = Guid.NewGuid(),
                Direction = data.wind.Direction,
                Speed = new ValueConverter().ConvertValue(data.wind.Speed, s.MinValue, s.MaxValue, s.MinSensor, s.MaxSensor),
                RegisterTime = DateTime.UtcNow
            };

            await _dbcontext.Temperature.AddAsync(temperature);
            await _dbcontext.Pressure.AddAsync(pressure);
            await _dbcontext.Humidity.AddAsync(humidity);
            await _dbcontext.Wind.AddAsync(wind);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
