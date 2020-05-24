using System;
using System.Collections.Generic;
using System.Text;
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

        public double CalculateWindChill()
        {
            double windChill = temperatureSensor.CurrentTemperature().Value - 2 * windSpeedSensor.CurrentSpeed().Value;
            return windChill;
        }
    }
}
