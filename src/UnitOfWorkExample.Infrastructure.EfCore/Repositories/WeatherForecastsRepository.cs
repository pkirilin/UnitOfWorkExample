using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;

namespace UnitOfWorkExample.Infrastructure.EfCore.Repositories
{
    public class WeatherForecastsRepository : Repository<WeatherForecast, int>, IWeatherForecastsRepository
    {
        public WeatherForecastsRepository(DbSet<WeatherForecast> entities) : base(entities)
        {
        }
    }
}