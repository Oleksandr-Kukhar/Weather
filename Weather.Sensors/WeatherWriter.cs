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


        public async Task WriteIndicatorsAsync(Indicator data)
        {
            var temperature = new Temperature()
            {
                Id = Guid.NewGuid(),
                Value = data.main.Temperature,
                RegisterTime = DateTime.UtcNow
            };

            var pressure = new Pressure()
            {
                Id = Guid.NewGuid(),
                Value = data.main.Pressure, 
                RegisterTime = DateTime.UtcNow
            };

            var humidity = new Humidity()
            {
                Id = Guid.NewGuid(),
                Value = data.main.Humidity,
                RegisterTime = DateTime.UtcNow
            };

            var wind = new Persistence.Model.Wind()
            {
                Id = Guid.NewGuid(),
                Direction = data.wind.Direction,
                Speed = data.wind.Speed,
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
