using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IWeatherForecastsRepository : IRepository<WeatherForecast>
    {
    }
}