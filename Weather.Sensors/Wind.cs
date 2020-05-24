using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Sensors
{
    public class Wind
    {
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Direction { get; set; }
    }
}
