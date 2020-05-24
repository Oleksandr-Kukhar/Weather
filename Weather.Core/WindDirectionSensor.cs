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
            string result = "";

            return result;
        }
    }
}
