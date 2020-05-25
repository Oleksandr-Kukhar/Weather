using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Web.DTO
{
    public class PrimaryDataDTO
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int WindDirection { get; set; }
        public string WindDirectionStr { get; set; }
        public double WindSpeed { get; set; }
    }
}
