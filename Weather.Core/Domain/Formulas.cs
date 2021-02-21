using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Domain
{
    public class Formulas
    {
        public static double CalculateWindChill(double temperature, double windSpeed)
        {
            double windChill = temperature - 2 * windSpeed;
            return windChill;
        }
        public static double CalculateDewPoint(double temperature, double huminity)
        {
            double dewPoint = temperature - (1 - huminity / 100) / 0.05;
            return dewPoint;
        }
    }
}
