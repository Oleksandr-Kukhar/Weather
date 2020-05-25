using System;
using System.Collections.Generic;
using System.Text;
using Weather.Core.Domain;

namespace Weather.Core
{
    public class DewPoint
    {
        private TemperatureSensor temperatureSensor;
        private HumiditySensor humiditySensor;

        public DewPoint(TemperatureSensor temperature, HumiditySensor humidity)
        {
            temperatureSensor = temperature;
            humiditySensor = humidity;
        }

        public double CalculateDewPoint(MinMaxUnit minmaxTemperature, MinMaxUnit minmaxHumidity)
        {
            double dewPoint = temperatureSensor.CurrentTemperature(minmaxTemperature).Value - (1 - humiditySensor.CurrentHumidity(minmaxHumidity).Value / 100) / 0.05;
            return dewPoint;
        }
    }
}
