using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Sensors
{
    public class SuperSys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public double Sunrise { get; set; }
        public double Sunset { get; set; }
    }
}
