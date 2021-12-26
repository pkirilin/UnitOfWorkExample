using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;
using UnitOfWorkExample.Infrastructure.Dapper.Entities;

namespace UnitOfWorkExample.Infrastructure.Dapper.Repositories
{
    internal class WeatherForecastsRepository : Repository<WeatherForecast, WeatherForecastPersistentEntity, int>,
        IWeatherForecastsRepository
    {
        public WeatherForecastsRepository(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public async Task<List<WeatherForecast>> GetForecastsAsync(CancellationToken cancellationToken)
        {
            var cmd = new CommandDefinition($"select * from {TableName} limit 100",
                transaction: Transaction,
                cancellationToken: cancellationToken);

            var forecasts = await Connection.QueryAsync<WeatherForecastPersistentEntity>(cmd);

            return forecasts
                .Select(MapToDomainEntity)
                .ToList();
        }

        protected override WeatherForecastPersistentEntity MapToPersistentEntity(WeatherForecast entity)
        {
            return new WeatherForecastPersistentEntity
            {
                Id = entity.Id,
                Date = entity.Date,
                Summary = entity.Summary.Text,
                TemperatureC = entity.TemperatureC
            };
        }

        protected override WeatherForecast MapToDomainEntity(WeatherForecastPersistentEntity entity)
        {
            return new WeatherForecast(entity.Id)
                .SetDate(entity.Date)
                .SetSummary(entity.Summary)
                .SetCelciusTemperature(entity.TemperatureC);
        }

        protected override void SetPersistentEntityId(WeatherForecastPersistentEntity entity, int id)
        {
            entity.Id = id;
        }
    }
}