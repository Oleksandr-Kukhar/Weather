using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Web.DTO
{
    public class SecondaryDataDTO
    {
        public int DewPoint { get; set; }
        public int WindChill { get; set; }
        public int MinimalTemperature { get; set; }
        public int MaximalTemperature { get; set; }
        public int MinimalPressure { get; set; }
        public int MaximalPressure { get; set; }
        public int MinimalHumidity { get; set; }
        public int MaximalHumidity { get; set; }
        public string MinimalTemperatureTime { get; set; }
        public string MaximalTemperatureTime { get; set; }
        public string MinimalPressureTime { get; set; }
        public string MaximalPressureTime { get; set; }
        public string MinimalHumidityTime { get; set; }
        public string MaximalHumidityTime { get; set; }
    }
}
