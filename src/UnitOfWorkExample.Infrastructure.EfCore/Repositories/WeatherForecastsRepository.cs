using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<List<WeatherForecast>> GetForecastsAsync(CancellationToken cancellationToken)
        {
            return await Entities
                .OrderByDescending(wf => wf.Date)
                .ToListAsync(cancellationToken);
        }
    }
}