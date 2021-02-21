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
    public class HumidityStorage : IHumidityStorage
    {
        private SensorsDataBaseContext _dbContext;

        public HumidityStorage(SensorsDataBaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Humidity> GetLastValueAsync()
        {
            var lastValue = (await _dbContext.Humidity.OrderByDescending(x=> x.RegisterTime).FirstOrDefaultAsync());
            return lastValue;
        }

        public async Task<Humidity> GetMaxValueAsync(DateTime date)
        {
            var maxValue = await _dbContext.Humidity.Where(x => x.RegisterTime.Date == date.Date).MaxAsync(x => x.Value);
            var humidity = await _dbContext.Humidity.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Value == maxValue);
            return humidity;
        }

        public async Task<Humidity> GetMinValueAsync(DateTime date)
        {
            var minValue = await _dbContext.Humidity.Where(x => x.RegisterTime.Date == date.Date).MinAsync(x => x.Value);
            var humidity = await _dbContext.Humidity.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Value == minValue);
            return humidity;
        }
        public double GetMinimalHumidity()
        {
            return _dbContext.Humidity.Where(x => x.RegisterTime.Date == DateTime.Now.Date).Min(x => x.Value);
        }

        public double GetMaximalHumidity()
        {
            return _dbContext.Humidity.Where(x => x.RegisterTime.Date == DateTime.Now.Date).Max(x => x.Value);
        }
    }
}
