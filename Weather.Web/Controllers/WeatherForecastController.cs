using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Core;
using Weather.Core.Domain;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;
using Weather.Persistence.Infrastructure.Storage.Intefaces;
using Weather.Sensors;
using Weather.Web.DTO;

namespace Weather.Web.Controllers
{
    [ApiController]

    public class WeatherForecastController : ControllerBase
    {
        private ITemperatureStorage _temperatureStorage;
        private IWindStorage _windStorage;
        private IHumidityStorage _humidityStorage;
        private IPressureStorage _pressureStorage;
        private IDataManager _dataManager;

        public MinMaxUnit _minmaxTemperature;
        public MinMaxUnit _minmaxHumidity;
        public MinMaxUnit _minmaxPressure;
        public MinMaxUnit _minmaxWindSpeed;


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITemperatureStorage temperatureStorage, IPressureStorage pressureStorage, IWindStorage windStorage, IHumidityStorage humidityStorage, IDataManager manager)
        {
            _logger = logger;
            _temperatureStorage = temperatureStorage;
            _humidityStorage = humidityStorage;
            _pressureStorage = pressureStorage;
            _windStorage = windStorage;
            _dataManager = manager;

            _minmaxTemperature = new MinMaxUnit()
            {
                MinValue = 278,
                MaxValue = 288,
                MinSensor = 20,
                MaxSensor = 30,
            };
            _minmaxHumidity = new MinMaxUnit()
            {
                MinValue = 30,
                MaxValue = 100,
                MinSensor = 50,
                MaxSensor = 75,
            };
            _minmaxPressure = new MinMaxUnit()
            {
                MinValue = 1000,
                MaxValue = 1100,
                MinSensor = 200,
                MaxSensor = 1000,
            };
            _minmaxWindSpeed = new MinMaxUnit()
            {
                MinValue = 0,
                MaxValue = 10,
                MinSensor = 0,
                MaxSensor = 1000,
            };
            _dataManager.StartDataRetreivingAsync(_minmaxTemperature, _minmaxPressure, _minmaxWindSpeed, _minmaxHumidity);


        }

        private void ChangeMinMaxValue(int valueId, double minValue, double maxValue, double minSensor, double maxSensor)
        {
            switch (valueId)
            {
                case 1:
                    _minmaxTemperature.MinValue = minValue;
                    _minmaxTemperature.MaxValue = maxValue;
                    _minmaxTemperature.MinSensor = minSensor;
                    _minmaxTemperature.MaxSensor = maxSensor;
                    break;
                case 2:
                    _minmaxHumidity.MinValue = minValue;
                    _minmaxHumidity.MaxValue = maxValue;
                    _minmaxHumidity.MinSensor = minSensor;
                    _minmaxHumidity.MaxSensor = maxSensor;
                    break;
                case 3:
                    _minmaxPressure.MinValue = minValue;
                    _minmaxPressure.MaxValue = maxValue;
                    _minmaxPressure.MinSensor = minSensor;
                    _minmaxPressure.MaxSensor = maxSensor;
                    break;
                case 4:
                    _minmaxWindSpeed.MinValue = minValue;
                    _minmaxWindSpeed.MaxValue = maxValue;
                    _minmaxWindSpeed.MinSensor = minSensor;
                    _minmaxWindSpeed.MaxSensor = maxSensor;
                    break;
                default:
                    break;
            }
        }

        [HttpGet]
        [Route("checkvalues")]
        public async Task<IActionResult> CheckValues()
        {
            var temperatureSensor = new TemperatureSensor(_temperatureStorage);
            var pressureSensor = new PressureSensor(_pressureStorage);
            var humiditySensor = new HumiditySensor(_humidityStorage);
            var windDirectionSensor = new WindDirectionSensor(_windStorage);
            var windSpeedSensor = new WindSpeedSensor(_windStorage);

            if ((int)temperatureSensor.HighTemperature(_minmaxTemperature).Value != (int)_minmaxTemperature.MaxValue || (int)temperatureSensor.LowTemperature(_minmaxTemperature).Value != (int)_minmaxTemperature.MinValue)
            {
                ChangeMinMaxValue(1, temperatureSensor.LowTemperature(_minmaxTemperature).Value, temperatureSensor.HighTemperature(_minmaxTemperature).Value, temperatureSensor.LowValue(), temperatureSensor.HighValue());
                _dataManager.StopThat();
                Thread.Sleep(1000);
                _dataManager.StartDataRetreivingAsync(_minmaxTemperature, _minmaxPressure, _minmaxWindSpeed, _minmaxHumidity);
            }
            if ((int)humiditySensor.HighHumidity(_minmaxHumidity).Value != (int)_minmaxHumidity.MaxValue || (int)humiditySensor.LowHumidity(_minmaxHumidity).Value != (int)_minmaxHumidity.MinValue)
            {
                ChangeMinMaxValue(2, humiditySensor.LowHumidity(_minmaxHumidity).Value, humiditySensor.HighHumidity(_minmaxHumidity).Value, humiditySensor.LowValue(), humiditySensor.HighValue());
                _dataManager.StopThat();
                Thread.Sleep(1000);
                _dataManager.StartDataRetreivingAsync(_minmaxTemperature, _minmaxPressure, _minmaxWindSpeed, _minmaxHumidity);
            }
            if ((int)pressureSensor.LowPressure(_minmaxPressure).Value != (int)_minmaxPressure.MinValue || (int)pressureSensor.HighPressure(_minmaxPressure).Value != (int)_minmaxPressure.MaxValue)
            {
                ChangeMinMaxValue(3, pressureSensor.LowPressure(_minmaxPressure).Value, pressureSensor.HighPressure(_minmaxPressure).Value, pressureSensor.LowValue(), pressureSensor.HighValue());
                _dataManager.StopThat();
                Thread.Sleep(1000);
                _dataManager.StartDataRetreivingAsync(_minmaxTemperature, _minmaxPressure, _minmaxWindSpeed, _minmaxHumidity);
            }
            if ((int)windSpeedSensor.LowSpeed(_minmaxWindSpeed).Value != (int)_minmaxWindSpeed.MinValue || (int)windSpeedSensor.HighSpeed(_minmaxWindSpeed).Value != (int)_minmaxWindSpeed.MaxValue)
            {
                ChangeMinMaxValue(4, windSpeedSensor.LowSpeed(_minmaxWindSpeed).Value, windSpeedSensor.HighSpeed(_minmaxWindSpeed).Value, windSpeedSensor.LowValue(), windSpeedSensor.HighValue());
                _dataManager.StopThat();
                Thread.Sleep(1000);
                _dataManager.StartDataRetreivingAsync(_minmaxTemperature, _minmaxPressure, _minmaxWindSpeed, _minmaxHumidity);
            }

            return Ok();
        }

        [HttpGet]
        [Route("getsensordata")]
        public async Task<IActionResult> GetForecastAsync()
        {
            var temperatureSensor = new TemperatureSensor(_temperatureStorage);
            var pressureSensor = new PressureSensor(_pressureStorage);
            var humiditySensor = new HumiditySensor(_humidityStorage);
            var windDirectionSensor = new WindDirectionSensor(_windStorage);
            var windSpeedSensor = new WindSpeedSensor(_windStorage);

            var minmaxtemp = _minmaxTemperature;


            var result = new PrimaryDataDTO()
            {
                Date = DateTime.UtcNow.AddDays(-7).ToShortDateString(),
                Time = DateTime.Now.TimeOfDay.ToString().Substring(0, 5),
                Humidity = (int)humiditySensor.CurrentHumidity(_minmaxHumidity).Value,
                Pressure = (int)pressureSensor.CurrentPressure(_minmaxPressure).Value,
                Temperature = (int)temperatureSensor.CurrentTemperature(_minmaxTemperature).Value,
                WindDirection = windDirectionSensor.CurrentDirection(),
                WindSpeed = windSpeedSensor.CurrentSpeed(_minmaxWindSpeed).Value,
                WindDirectionStr = windDirectionSensor.CurrentDirectionString()
            };
            return Ok(result);
        }


        [HttpGet]
        [Route("startretrievingdata")]
        public async Task<IActionResult> StartRetrievingData()
        {
            if (_minmaxTemperature == null)
            {

            }
            _dataManager.StartDataRetreivingAsync(_minmaxTemperature, _minmaxPressure, _minmaxWindSpeed, _minmaxHumidity);

            return Ok();
        }

        [HttpGet]
        [Route("stopretrievingdata")]
        public async Task<IActionResult> StopRetrievingData()
        {
            _dataManager.StopThat();

            return Ok();
        }

        [HttpGet]
        [Route("getsecondarydata")]
        public async Task<IActionResult> GetSecondaryDataAsync()
        {
            var temperatureSensor = new TemperatureSensor(_temperatureStorage);
            var pressureSensor = new PressureSensor(_pressureStorage);
            var humiditySensor = new HumiditySensor(_humidityStorage);
            var windDirectionSensor = new WindDirectionSensor(_windStorage);
            var windSpeedSensor = new WindSpeedSensor(_windStorage);
            var windChill = new WindChill(temperatureSensor, windSpeedSensor);
            var dewPoint = new DewPoint(temperatureSensor, humiditySensor);
            var timeSpan = new TimeSpan(3, 0, 0);

            var result = new SecondaryDataDTO()
            {
                WindChill = (int)windChill.CalculateWindChill(_minmaxTemperature, _minmaxWindSpeed),
                DewPoint = (int)dewPoint.CalculateDewPoint(_minmaxTemperature, _minmaxHumidity),
                MaximalTemperature = (int)temperatureSensor.HighTemperature(_minmaxTemperature).Value,
                MinimalTemperature = (int)temperatureSensor.LowTemperature(_minmaxTemperature).Value,
                MaximalHumidity = (int)humiditySensor.HighHumidity(_minmaxHumidity).Value,
                MinimalHumidity = (int)humiditySensor.LowHumidity(_minmaxHumidity).Value,
                MinimalPressure = (int)pressureSensor.LowPressure(_minmaxPressure).Value,
                MaximalPressure = (int)pressureSensor.HighPressure(_minmaxPressure).Value,
                MinimalTemperatureTime = temperatureSensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalTemperatureTime = temperatureSensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MinimalHumidityTime = humiditySensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalHumidityTime = humiditySensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MinimalPressureTime = pressureSensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalPressureTime = pressureSensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
            };
            return Ok(result);
        }

        [HttpGet]
        [Route("change/{id}/{minValue}/{maxValue}")]
        public async Task<IActionResult> CallibrateSensor(int id, int minValue, int maxValue)
        {

            switch (id)
            {
                case 1:
                    var temperatureSensor = new TemperatureSensor(_temperatureStorage);
                    minValue = minValue + 273;
                    maxValue = maxValue + 273;
                    temperatureSensor.SetHighValue(maxValue);
                    temperatureSensor.SetLowValue(minValue);
                    break;
                case 2:
                    var humiditySensor = new HumiditySensor(_humidityStorage);
                    humiditySensor.SetHighValue(maxValue);
                    humiditySensor.SetLowValue(minValue);
                    break;
                case 3:
                    var pressureSensor = new PressureSensor(_pressureStorage);
                    pressureSensor.SetHighValue(maxValue);
                    pressureSensor.SetLowValue(minValue);
                    break;
                case 4:
                    var windSpeedSensor = new WindSpeedSensor(_windStorage);
                    windSpeedSensor.SetHighValue(maxValue);
                    windSpeedSensor.SetLowValue(minValue);
                    break;
                default:
                    break;
            }
            return Ok();
        }
    }
}
