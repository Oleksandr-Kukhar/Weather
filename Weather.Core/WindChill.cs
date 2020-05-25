using System;
using System.Collections.Generic;
using System.Text;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure.Storage;

namespace Weather.Core
{
    public class WindChill
    {
        private TemperatureSensor temperatureSensor;
        private WindSpeedSensor windSpeedSensor;

        public WindChill(TemperatureSensor temperature, WindSpeedSensor windSpeed)
        {
            temperatureSensor = temperature;
            windSpeedSensor = windSpeed;
        }

        public double CalculateWindChill(MinMaxUnit minmaxTemperature, MinMaxUnit minmaxWindSpeed)
        {
            double windChill = temperatureSensor.CurrentTemperature(minmaxTemperature).Value - 2 * windSpeedSensor.CurrentSpeed(minmaxWindSpeed).Value;
            return windChill;
        }
    }
}
