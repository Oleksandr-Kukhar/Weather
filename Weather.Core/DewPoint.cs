using System;
using System.Collections.Generic;
using System.Text;

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

        public double CalculateDewPoint()
        {
            double dewPoint = temperatureSensor.CurrentTemperature().Value - (1 - humiditySensor.CurrentHumidity().Value / 100) / 0.05;
            return dewPoint;
        }
    }
}
