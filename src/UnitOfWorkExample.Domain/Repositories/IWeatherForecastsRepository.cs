using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Domain.Repositories
{
    public interface IWeatherForecastsRepository : IRepository<WeatherForecast, int>
    {
        Task<List<WeatherForecast>> GetForecastsAsync(CancellationToken cancellationToken);
    }
}