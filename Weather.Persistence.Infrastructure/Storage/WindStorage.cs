using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;
using Weather.Persistence.Infrastructure.Storage.Intefaces;

namespace Weather.Persistence.Infrastructure.Storage
{
    public class WindStorage : IWindStorage
    {
        private SensorsDataBaseContext _dbContext;

        public WindStorage(SensorsDataBaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Wind> GetLastValueAsync()
        {
            var lastValue = (await _dbContext.Wind.OrderByDescending(x => x.RegisterTime).FirstOrDefaultAsync());
            return lastValue;
        }

        public async Task<Wind> GetMaxValueAsync(DateTime date)
        {
            var maxValue = await _dbContext.Wind.Where(x => x.RegisterTime.Date == date.Date).MaxAsync(x => x.Speed);
            var wind = await _dbContext.Wind.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Speed == maxValue);
            return wind;
        }

        public async Task<Wind> GetMinValueAsync(DateTime date)
        {
            var minValue = await _dbContext.Wind.Where(x => x.RegisterTime.Date == date.Date).MinAsync(x => x.Speed);
            var wind = await _dbContext.Wind.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Speed == minValue);
            return wind;
        }
        public double GetMinimalWindSpeed()
        {
            return _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MinimalWindSpeed").Value;
        }

        public double GetMaximalWindSpeed()
        {
            return _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MaximalWindSpeed").Value;
        }
        public void ChangeMinimalWindSpeed(double newWindSpeed)
        {
            var temperature = _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MinimalWindSpeed");
            temperature.Value = newWindSpeed;
            _dbContext.SaveChanges();
        }
        public void ChangeMaximalWindSpeed(double newWindSpeed)
        {
            var temperature = _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MaximalWindSpeed");
            temperature.Value = newWindSpeed;
            _dbContext.SaveChanges();
        }
    }
}
