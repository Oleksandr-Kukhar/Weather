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
using Weather.Services.Interfaces;
using Weather.Web.DTO;

namespace Weather.Web.Controllers
{
    [ApiController]

    public class WeatherForecastController : ControllerBase
    {
        private readonly ICalibrationService _calibrationService;
        private readonly IDataManager _dataManager;

        private readonly HistoricalSensor<TemperatureUnit> _temperatureSensor;
        private readonly HistoricalSensor<HumidityUnit> _humiditySensor;
        private readonly HistoricalSensor<PressureUnit> _pressureSensor;
        private readonly HistoricalSensor<SpeedUnit> _windSensor;
        private readonly WindDirectionSensor _windDirectionSensor;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            ICalibrationService calibrationService,
            IDataManager manager,
            HistoricalSensor<TemperatureUnit> temperatureSensor,
            HistoricalSensor<HumidityUnit> humiditySensor,
            HistoricalSensor<PressureUnit> pressureSensor,
            HistoricalSensor<SpeedUnit> windSensor,
            WindDirectionSensor windDirectionSensor)
        {
            _logger = logger;
            _calibrationService = calibrationService;
            _temperatureSensor = temperatureSensor;
            _humiditySensor = humiditySensor;
            _pressureSensor = pressureSensor;
            _windSensor = windSensor;
            _windDirectionSensor = windDirectionSensor;

            _dataManager = manager;

            // Якось потім пофікшу
            //_dataManager.StartDataRetreivingAsync();
        }

        [HttpGet]
        [Route("checkvalues")]
        public IActionResult CheckValues()
        {

            return Ok();
        }

        [HttpGet]
        [Route("getsensordata")]
        public IActionResult GetForecast()
        {
            var result = new PrimaryDataDTO()
            {
                Date = DateTime.UtcNow.ToShortDateString(),
                Time = DateTime.Now.TimeOfDay.ToString().Substring(0, 5),
                Humidity = (int)_humiditySensor.CurrentValue(),
                Pressure = (int)_pressureSensor.CurrentValue(),
                Temperature = (int)_temperatureSensor.CurrentValue(),
                WindDirection = _windDirectionSensor.CurrentDirection(),
                WindSpeed = _windSensor.CurrentValue(),
                WindDirectionStr = _windDirectionSensor.CurrentDirectionString()
            };

            return Ok(result);
        }


        [HttpGet]
        [Route("startretrievingdata")]
        public async Task<IActionResult> StartRetrievingData()
        {
            await _dataManager.StartDataRetreivingAsync();

            return Ok();
        }

        [HttpGet]
        [Route("stopretrievingdata")]
        public IActionResult StopRetrievingData()
        {
            _dataManager.StopThat();

            return Ok();
        }

        [HttpGet]
        [Route("getsecondarydata")]
        public IActionResult GetSecondaryData()
        {
            var timeSpan = DateTime.Now - DateTime.UtcNow;

            var result = new SecondaryDataDTO()
            {
                WindChill = (int)Formulas.CalculateWindChill(_temperatureSensor.CurrentValue(), _windSensor.CurrentValue()),
                DewPoint = (int)Formulas.CalculateDewPoint(_temperatureSensor.CurrentValue(), _humiditySensor.CurrentValue()),
                MaximalTemperature = (int)_temperatureSensor.HighValue(),
                MinimalTemperature = (int)_temperatureSensor.LowValue(),
                MaximalHumidity = (int)_humiditySensor.HighValue(),
                MinimalHumidity = (int)_humiditySensor.LowValue(),
                MinimalPressure = (int)_pressureSensor.LowValue(),
                MaximalPressure = (int)_pressureSensor.HighValue(),
                MinimalTemperatureTime = _temperatureSensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalTemperatureTime = _temperatureSensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MinimalHumidityTime = _humiditySensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalHumidityTime = _humiditySensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MinimalPressureTime = _pressureSensor.TimeOfLowValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
                MaximalPressureTime = _pressureSensor.TimeOfHighValue().TimeOfDay.Add(timeSpan).ToString().Substring(0, 5),
            };
            
            return Ok(result);
        }

        [HttpGet]
        [Route("change/{id}/{minValue}/{maxValue}")]
        public IActionResult CallibrateSensor(int id, int minValue, int maxValue)
        {
            switch (id)
            {
                case 1:
                    _calibrationService.CalibrateTemperatureSensor(minValue + 273, maxValue + 273);
                    break;
                case 2:
                    _calibrationService.CalibrateHumiditySensor(minValue, maxValue);
                    break;
                case 3:
                    _calibrationService.CalibratePressureSensor(minValue, maxValue);
                    break;
                case 4:
                    _calibrationService.CalibrateWindSpeedSensor(minValue, maxValue);
                    break;
                default:
                    break;
            }
            return Ok();
        }
    }
}
