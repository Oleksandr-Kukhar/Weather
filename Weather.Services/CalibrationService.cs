using Weather.Core;
using Weather.Services.Interfaces;
using Weather.Persistence.Infrastructure.Storage.Intefaces;
using Weather.Core.Domain;

namespace Weather.Services
{
    public class CalibrationService : ICalibrationService
    {
        private readonly HistoricalSensor<TemperatureUnit> _temperatureSensor;
        private readonly HistoricalSensor<HumidityUnit> _humiditySensor;
        private readonly HistoricalSensor<PressureUnit> _pressureSensor;
        private readonly HistoricalSensor<SpeedUnit> _windSensor;
        private readonly ITemperatureStorage _temperatureStorage;
        private readonly IHumidityStorage _humidityStorage;
        private readonly IPressureStorage _pressureStorage;
        private readonly IWindStorage _windStorage;

        public CalibrationService(
            ITemperatureStorage temperatureStorage,
            IHumidityStorage humidityStorage,
            IPressureStorage pressureStorage,
            IWindStorage windStorage,
            HistoricalSensor<TemperatureUnit> temperatureSensor,
            HistoricalSensor<HumidityUnit> humiditySensor,
            HistoricalSensor<PressureUnit> pressureSensor,
            HistoricalSensor<SpeedUnit> windSensor
            )
        {
            _temperatureStorage = temperatureStorage;
            _humidityStorage = humidityStorage;
            _pressureStorage = pressureStorage;
            _windStorage = windStorage;

            _temperatureSensor = temperatureSensor;
            _humiditySensor = humiditySensor;
            _pressureSensor = pressureSensor;
            _windSensor = windSensor;
        }

        public void CalibrateTemperatureSensor(int minValue, int maxValue)
        {
            _temperatureSensor.SetRealHighValue(maxValue);
            _temperatureSensor.SetRealLowValue(minValue);

            _temperatureSensor.SetHighValue(_temperatureStorage.GetMaximalTemperature());
            _temperatureSensor.SetLowValue(_temperatureStorage.GetMinimalTemperature());
        }

        public void CalibrateHumiditySensor(int minValue, int maxValue)
        {
            _humiditySensor.SetRealHighValue(maxValue);
            _humiditySensor.SetRealLowValue(minValue);

            _humiditySensor.SetHighValue(_humidityStorage.GetMaximalHumidity());
            _humiditySensor.SetLowValue(_humidityStorage.GetMinimalHumidity());
        }

        public void CalibratePressureSensor(int minValue, int maxValue)
        {
            _pressureSensor.SetRealHighValue(maxValue);
            _pressureSensor.SetRealLowValue(minValue);

            _pressureSensor.SetHighValue(_pressureStorage.GetMaximalPressure());
            _pressureSensor.SetLowValue(_pressureStorage.GetMinimalPressure());
        }

        public void CalibrateWindSpeedSensor(int minValue, int maxValue)
        {
            _windSensor.SetRealHighValue(maxValue);
            _windSensor.SetRealLowValue(minValue);

            _windSensor.SetHighValue(_windStorage.GetMaximalWindSpeed());
            _windSensor.SetLowValue(_windStorage.GetMinimalWindSpeed());
        }
    }
}
