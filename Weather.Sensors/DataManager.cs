using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Persistence.Infrastructure;

namespace Weather.Sensors
{
    public class DataManager : IDataManager
    {
        private bool _shouldRetrieveData = false;

        public DataManager()
        {
        }
        public async Task StartDataRetreivingAsync()
        {
            if(!_shouldRetrieveData)
            {
                _shouldRetrieveData = true;
                MainSensor mainSensor = new MainSensor();

                while (_shouldRetrieveData)
                {

                    using (var context = new SensorsDataBaseContext())
                    {
                        WeatherWriter weatherWriter = new WeatherWriter(context);
                        var indicators = await mainSensor.GetIndicatorsAsync();
                        await weatherWriter.WriteIndicatorsAsync(indicators);

                    }
                    Thread.Sleep(60000);
                }
            }
        }

        public void StopThat()
        {
            _shouldRetrieveData = false;
        }
    }
}
