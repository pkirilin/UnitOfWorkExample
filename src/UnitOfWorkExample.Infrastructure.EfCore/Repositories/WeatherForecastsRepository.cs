using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Entities;

namespace UnitOfWorkExample.Infrastructure.EfCore.Repositories
{
    public class WeatherForecastsRepository : Repository<WeatherForecast>, IWeatherForecastsRepository
    {
        public WeatherForecastsRepository(DbSet<WeatherForecast> entities) : base(entities)
        {
        }
    }
}