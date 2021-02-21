using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Domain;

namespace Weather.Sensors
{
    public interface IDataManager
    {
        Task StartDataRetreivingAsync();
        void StopThat();
    }
}
