using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Domain.Repositories
{
    public interface IWeatherForecastsRepository : IRepository<WeatherForecast, int>
    {
    }
}