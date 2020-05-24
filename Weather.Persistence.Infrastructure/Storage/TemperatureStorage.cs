using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage
{
    public class TemperatureStorage : ITemperatureStorage
    {
        private SensorsDataBaseContext _dbContext;

        public TemperatureStorage(SensorsDataBaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Temperature> GetLastValueAsync()
        {
            var lastValue = (await _dbContext.Temperature.OrderByDescending(x => x.RegisterTime).FirstOrDefaultAsync());
            return lastValue;
        }

        public async Task<Temperature> GetMaxValueAsync(DateTime date)
        {
            var maxValue = await _dbContext.Temperature.Where(x => x.RegisterTime.Date == date.Date).MaxAsync(x => x.Value);
            var temperature = await _dbContext.Temperature.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Value == maxValue);
            return temperature;
        }

        public async Task<Temperature> GetMinValueAsync(DateTime date)
        {
            var minValue = await _dbContext.Temperature.Where(x => x.RegisterTime.Date == date.Date).MinAsync(x => x.Value);
            var temperature = await _dbContext.Temperature.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Value == minValue);
            return temperature;
        }

    }
}
