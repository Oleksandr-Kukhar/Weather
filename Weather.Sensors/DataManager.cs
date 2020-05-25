using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;

namespace Weather.Sensors
{
    public class DataManager : IDataManager
    {
        private bool _shouldRetrieveData = false;

        public DataManager()
        {
        }
        public async Task StartDataRetreivingAsync(MinMaxUnit temperature, MinMaxUnit pressure, MinMaxUnit windSpeed, MinMaxUnit humidity)
        {
            if(!_shouldRetrieveData)
            {
                _shouldRetrieveData = true;
                MainSensor mainSensor = new MainSensor();

                while (_shouldRetrieveData)
                {
                    if (DateTime.Now.Second == 30)
                    {
                        using (var context = new SensorsDataBaseContext())
                        {
                            WeatherWriter weatherWriter = new WeatherWriter(context);
                            var indicators = await mainSensor.GetIndicatorsAsync();
                            await weatherWriter.WriteIndicatorsAsync(indicators, temperature, pressure, windSpeed, humidity);

                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        public void StopThat()
        {
            _shouldRetrieveData = false;
        }
    }
}
