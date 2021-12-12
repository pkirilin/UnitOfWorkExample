using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;
using UnitOfWorkExample.Infrastructure.NHibernate.Entities;

namespace UnitOfWorkExample.Infrastructure.NHibernate.Repositories
{
    internal class WeatherForecastsRepository :
        Repository<WeatherForecast, WeatherForecastPersistentEntity, int>,
        IWeatherForecastsRepository
    {
        public WeatherForecastsRepository(ISession session) : base(session)
        {
        }
        
        public async Task<List<WeatherForecast>> GetForecastsAsync(CancellationToken cancellationToken)
        {
            var forecasts = await Session
                .Query<WeatherForecastPersistentEntity>()
                .OrderByDescending(wf => wf.Date)
                .ToListAsync(cancellationToken);
            
            return forecasts.Select(MapToDomainEntity).ToList();
        }

        protected override WeatherForecast MapToDomainEntity(WeatherForecastPersistentEntity entity)
        {
            return new WeatherForecast(entity.Id)
                .SetDate(entity.Date)
                .SetCelciusTemperature(entity.TemperatureC)
                .SetSummary(entity.Summary);
        }

        protected override WeatherForecastPersistentEntity MapToPersistentEntity(WeatherForecast entity)
        {
            return new WeatherForecastPersistentEntity
            {
                Id = entity.Id,
                Date = entity.Date,
                TemperatureC = entity.TemperatureC,
                Summary = entity.Summary.Text
            };
        }

        protected override void SetPersistentEntityId(WeatherForecastPersistentEntity entity, int id)
        {
            entity.Id = id;
        }
    }
}