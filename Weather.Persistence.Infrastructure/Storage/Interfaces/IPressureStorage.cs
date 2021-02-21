using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage.Intefaces
{
    public interface IPressureStorage
    {
        Task<Pressure> GetLastValueAsync();
        Task<Pressure> GetMaxValueAsync(DateTime date);
        Task<Pressure> GetMinValueAsync(DateTime date);
        double GetMinimalPressure();
        double GetMaximalPressure();
        void ChangeMinimalPressure(double newPressure);
        void ChangeMaximalPressure(double newPressure);

    }
}
