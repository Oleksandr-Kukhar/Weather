using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage.Intefaces
{
    public interface IHumidityStorage
    {
        Task<Humidity> GetLastValueAsync();
        Task<Humidity> GetMaxValueAsync(DateTime date);
        Task<Humidity> GetMinValueAsync(DateTime date);
        double GetMinimalHumidity();
        double GetMaximalHumidity();
        void ChangeMinimalHumidity(double newHumidity);
        void ChangeMaximalHumidity(double newHumidity);
    }
}
