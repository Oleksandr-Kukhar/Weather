using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage.Intefaces
{
    public interface IWindStorage
    {
        Task<Wind> GetLastValueAsync();
        Task<Wind> GetMaxValueAsync(DateTime date);
        Task<Wind> GetMinValueAsync(DateTime date);
        double GetMinimalWindSpeed();
        public double GetMaximalWindSpeed();
        void ChangeMinimalWindSpeed(double newWindSpeed);
        void ChangeMaximalWindSpeed(double newWindSpeed);

    }
}
