using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Sensors
{
    public interface IDataManager
    {
        Task StartDataRetreivingAsync();
        void StopThat();
    }
}
