using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage.Intefaces;
using Weather.Persistence.Infrastructure.Storage.Interfaces;

namespace Weather.Sensors
{
    public class DataManager : IDataManager
    {
        private bool _shouldRetrieveData = false;

        private readonly IServiceScopeFactory _scopeFactory;

        public DataManager(IServiceScopeFactory serviceScopeFactory)
        {
            _scopeFactory = serviceScopeFactory;
            
        }

        public async Task StartDataRetreivingAsync()
        {
            if(!_shouldRetrieveData)
            {
                _shouldRetrieveData = true;
                MainSensor mainSensor = new MainSensor();

                while (_shouldRetrieveData)
                {
                    if ((DateTime.Now.Second + 1) % 15 == 0)
                    {
                        using var scope = _scopeFactory.CreateScope();
                        WeatherWriter weatherWriter = new WeatherWriter(scope.ServiceProvider.GetRequiredService<SensorsDataBaseContext>());
                        var indicators = await mainSensor.GetIndicatorsAsync();

                        await weatherWriter.WriteIndicatorsAsync(indicators);

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
