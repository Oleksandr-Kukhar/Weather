using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage.Intefaces
{
    public interface ITemperatureStorage
    {
        Task<Temperature> GetLastValueAsync();
        Task<Temperature> GetMaxValueAsync(DateTime date);
        Task<Temperature> GetMinValueAsync(DateTime date);
        double GetMinimalTemperature();
        double GetMaximalTemperature();
        void ChangeMinimalTemperature(double newTemperature);
        void ChangeMaximalTemperature(double newTemperature);
    }
}
