using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Sensors
{
    public class MainSensor
    {
        public async Task<Indicator> GetIndicatorsAsync()
        {
            string url = @"https://api.openweathermap.org/data/2.5/weather?q=Lviv&appid=e7ebf3327c91ff821e7bd4068ce11e3b";
            RequestHelper requestHelper = new RequestHelper();
            var serializedObject = await requestHelper.GetAsync(url);

            Indicator result = JsonConvert.DeserializeObject<Indicator>(serializedObject);

            return result;
        }
    }
}
