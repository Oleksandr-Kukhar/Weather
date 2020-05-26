using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;

namespace Weather.Core
{
    public class WindDirectionSensor : Sensor
    {
        private IWindStorage _windStorage;

        public WindDirectionSensor(IWindStorage storage)
        {
           _windStorage  = storage;
        }
        public int CurrentDirection()
        {
            var direction = _windStorage.GetLastValueAsync().Result.Direction;
            return direction;
        }
        public string CurrentDirectionString()
        {
            string windDirectionStr = "";
            var direct = _windStorage.GetLastValueAsync().Result.Direction;
            if (direct >= 337 || direct < 22)
            {
                windDirectionStr = "N";
            }
            if (direct >= 22 && direct < 67)
            {
                windDirectionStr = "NE";
            }
            if (direct >= 67 && direct < 112)
            {
                windDirectionStr = "E";
            }
            if (direct >= 112 && direct < 157)
            {
                windDirectionStr = "SE";
            }
            if (direct >= 157 && direct < 202)
            {
                windDirectionStr = "S";
            }
            if (direct >= 202 && direct < 247)
            {
                windDirectionStr = "SW";
            }
            if (direct >= 247 && direct < 292)
            {
                windDirectionStr = "W";
            }
            if (direct >= 292 && direct < 337)
            {
                windDirectionStr = "NW";
            }
            return windDirectionStr;
        }
    }
}
