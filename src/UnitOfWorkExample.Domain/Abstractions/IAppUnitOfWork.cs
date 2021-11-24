using UnitOfWorkExample.Domain.Repositories;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IWeatherForecastsRepository WeatherForecasts { get; }
    }
}