using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Core;
using Weather.Persistence.Infrastructure;
using Weather.Persistence.Infrastructure.Storage;
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

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,  ITemperatureStorage temperatureStorage, IPressureStorage pressureStorage, IWindStorage windStorage, IHumidityStorage humidityStorage, IDataManager manager)
        {
            _logger = logger;
            _temperatureStorage = temperatureStorage;
            _humidityStorage = humidityStorage;
            _pressureStorage = pressureStorage;
            _windStorage = windStorage;
            _dataManager = manager;
            _dataManager.StartDataRetreivingAsync();
        }

        [HttpGet]
        [Route("peisung")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
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

            var windDirectionStr = "";
            var direct = windDirectionSensor.CurrentDirection();
            {
                if (direct >= 337 || direct < 22)
                {
                    windDirectionStr = "N";
                }
                if (direct >= 22 && direct < 67)
                {
                    windDirectionStr = "NE";
                }
                if (direct >= 67 && direct < 112)
                {
                    windDirectionStr = "E";
                }
                if (direct >= 112 && direct < 157)
                {
                    windDirectionStr = "SE";
                }
                if (direct >= 157 && direct < 202)
                {
                    windDirectionStr = "S";
                }
                if (direct >= 202 && direct < 247)
                {
                    windDirectionStr = "SW";
                }
                if (direct >= 247 && direct < 292)
                {
                    windDirectionStr = "W";
                }
                if (direct >= 292 && direct < 337)
                {
                    windDirectionStr = "NW";
                }
            }
            var result = new PrimaryDataDTO()
            {
                Date = DateTime.UtcNow.AddDays(-7).ToShortDateString(),
                Time = DateTime.Now.TimeOfDay.ToString().Substring(0, 5),
                Humidity = (int)humiditySensor.CurrentHumidity().Value,
                Pressure = pressureSensor.CurrentPressure().Value,
                Temperature = (int)temperatureSensor.CurrentTemperature().Value,
                WindDirection  = windDirectionSensor.CurrentDirection(),
                WindSpeed = windSpeedSensor.CurrentSpeed().Value,
                WindDirectionStr = windDirectionStr
            };
            return Ok(result);
        }

        [HttpGet]
        [Route("startretrievingdata")]
        public async Task<IActionResult> StartRetrievingData()
        {
            _dataManager.StartDataRetreivingAsync();

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
                WindChill = (int)windChill.CalculateWindChill(),
                DewPoint = (int)dewPoint.CalculateDewPoint(),
                MaximalTemperature = (int)temperatureSensor.HighValue().Value,
                MinimalTemperature = (int)temperatureSensor.LowValue().Value,
                MaximalHumidity = (int)humiditySensor.HighValue().Value,
                MinimalHumidity = (int)humiditySensor.LowValue().Value,
                MinimalPressure = (int)pressureSensor.LowValue().Value,
                MaximalPressure = (int)pressureSensor.HighValue().Value,
                MinimalTemperatureTime = temperatureSensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalTemperatureTime = temperatureSensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MinimalHumidityTime = humiditySensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalHumidityTime = humiditySensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MinimalPressureTime = pressureSensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalPressureTime = pressureSensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
            };
            return Ok(result);
        }
    }
}
