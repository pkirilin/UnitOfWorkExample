using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Dtos;

namespace UnitOfWorkExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAppUnitOfWork _appUnitOfWork;

        public WeatherForecastController(IAppUnitOfWork appUnitOfWork)
        {
            _appUnitOfWork = appUnitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetForecasts(CancellationToken cancellationToken)
        {
            var weatherForecasts = await _appUnitOfWork.WeatherForecasts.GetForecastsAsync(cancellationToken);
            var result = weatherForecasts.Select(ToWeatherForecastItemDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetForecastById([FromQuery] int id, CancellationToken cancellationToken)
        {
            var forecast = await _appUnitOfWork.WeatherForecasts.GetByIdAsync(id, cancellationToken);
            
            if (forecast == null)
                return NotFound();
            
            var result = ToWeatherForecastItemDto(forecast);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateForecast([FromBody] WeatherForecastCreateUpdateDto body,
            CancellationToken cancellationToken)
        {
            var forecast = new WeatherForecast()
                .SetDate(body.Date)
                .SetCelciusTemperature(body.TemperatureC)
                .SetSummary(body.Summary);

            var newForecast = _appUnitOfWork.WeatherForecasts.Add(forecast);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);

            var result = ToWeatherForecastItemDto(newForecast);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateForecast([FromRoute] int id,
            [FromBody] WeatherForecastCreateUpdateDto body,
            CancellationToken cancellationToken)
        {
            var forecast = await _appUnitOfWork.WeatherForecasts.GetByIdAsync(id, cancellationToken);
            
            if (forecast == null)
                return NotFound();
            
            forecast.SetDate(body.Date)
                .SetCelciusTemperature(body.TemperatureC)
                .SetSummary(body.Summary);
            
            _appUnitOfWork.WeatherForecasts.Update(forecast);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteForecast([FromRoute] int id, CancellationToken cancellationToken)
        {
            var forecast = await _appUnitOfWork.WeatherForecasts.GetByIdAsync(id, cancellationToken);

            if (forecast == null)
                return NotFound();

            _appUnitOfWork.WeatherForecasts.Remove(forecast);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        private static WeatherForecastItemDto ToWeatherForecastItemDto(WeatherForecast forecast)
        {
            return new WeatherForecastItemDto
            {
                Id = forecast.Id,
                Date = forecast.Date,
                TemperatureC = forecast.TemperatureC,
                TemperatureF = forecast.TemperatureF,
                Summary = forecast.Summary.Text
            };
        }
    }
}
