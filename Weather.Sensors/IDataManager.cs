using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Domain;

namespace Weather.Sensors
{
    public interface IDataManager
    {
        Task StartDataRetreivingAsync(MinMaxUnit temperature, MinMaxUnit pressure, MinMaxUnit windSpeed, MinMaxUnit humidity);
        void StopThat();
    }
}
