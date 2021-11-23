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
            var weatherForecasts = await _appUnitOfWork.WeatherForecasts.GetAsync(cancellationToken);
            
            var result = weatherForecasts.Select(wf => new WeatherForecastItemDto
            {
                Id = wf.Id,
                Date = wf.Date,
                TemperatureC = wf.TemperatureC,
                TemperatureF = wf.TemperatureF,
                Summary = wf.Summary.Text
            });
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostWeatherForecast([FromBody] WeatherForecastCreateDto weatherForecastItemDto,
            CancellationToken cancellationToken)
        {
            var weatherForecastEntity = new WeatherForecast(weatherForecastItemDto.Date,
                weatherForecastItemDto.TemperatureC,
                weatherForecastItemDto.Summary);

            var id = await _appUnitOfWork.WeatherForecasts.AddAsync(weatherForecastEntity, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
            return Ok(id);
        }
    }
}
