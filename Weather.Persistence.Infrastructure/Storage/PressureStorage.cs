using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage
{
    public class PressureStorage : IPressureStorage
    {
        private SensorsDataBaseContext _dbContext;

        public PressureStorage(SensorsDataBaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Pressure> GetLastValueAsync()
        {
            var lastValue = (await _dbContext.Pressure.OrderByDescending(x => x.RegisterTime).FirstOrDefaultAsync());
            return lastValue;
        }

        public async Task<Pressure> GetMaxValueAsync(DateTime date)
        {
            var maxValue = await _dbContext.Pressure.Where(x => x.RegisterTime.Date == date.Date).MaxAsync(x => x.Value);
            var temperature = await _dbContext.Pressure.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Value == maxValue);
            return temperature;
        }

        public async Task<Pressure> GetMinValueAsync(DateTime date)
        {
            var minValue = await _dbContext.Pressure.Where(x => x.RegisterTime.Date == date.Date).MinAsync(x => x.Value);
            var temperature = await _dbContext.Pressure.FirstAsync(x => x.RegisterTime.Date == date.Date && x.Value == minValue);
            return temperature;
        }
        public double GetMinimalPressure()
        {
            return _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MinimalPressure").Value;
        }

        public double GetMaximalPressure()
        {
            return _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MaximalPressure").Value;
        }
        public void ChangeMinimalPressure(double newPressure)
        {
            var temperature = _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MinimalPressure");
            temperature.Value = newPressure;
            _dbContext.SaveChanges();
        }
        public void ChangeMaximalPressure(double newPressure)
        {
            var temperature = _dbContext.CriticalValues.FirstOrDefault(x => x.ValueName == "MaximalPressure");
            temperature.Value = newPressure;
            _dbContext.SaveChanges();
        }
    }
}
