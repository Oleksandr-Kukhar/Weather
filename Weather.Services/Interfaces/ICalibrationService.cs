using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Services.Interfaces
{
    public interface ICalibrationService
    {
        public void CalibrateTemperatureSensor(int minValue, int maxValue);

        public void CalibrateHumiditySensor(int minValue, int maxValue);

        public void CalibratePressureSensor(int minValue, int maxValue);

        public void CalibrateWindSpeedSensor(int minValue, int maxValue);
    }
}
