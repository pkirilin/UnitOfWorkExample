using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkExample.Domain.Abstractions;
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
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var weatherForecasts = await _appUnitOfWork.WeatherForecasts.GetAsync(cancellationToken);
            
            var result = weatherForecasts.Select(wf => new WeatherForecastItemDto
            {
                Id = wf.Id,
                Date = wf.Date,
                TemperatureC = wf.TemperatureC,
                TemperatureF = wf.TemperatureF,
                Summary = wf.Summary
            });
            
            return Ok(result);
        }
    }
}
