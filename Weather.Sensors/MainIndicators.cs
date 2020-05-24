using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Sensors
{
    public class MainIndicators
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("feels_like")]
        public double TemperatureFeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }
        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }
}
