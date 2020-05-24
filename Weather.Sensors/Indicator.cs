using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Sensors
{
    public class Indicator
    {
        public Coordinates coord { get; set; }
        public IEnumerable<Weather> weather { get; set; }
        public string Base { get; set; }
        public MainIndicators main { get; set; }
        public double visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public double Dt { get; set; }
        public Sys sys { get; set; }
        public double timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
