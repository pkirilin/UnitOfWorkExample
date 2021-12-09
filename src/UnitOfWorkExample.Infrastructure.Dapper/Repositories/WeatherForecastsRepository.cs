using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;
using UnitOfWorkExample.Infrastructure.Dapper.Contribs;

namespace UnitOfWorkExample.Infrastructure.Dapper.Repositories
{
    internal class WeatherForecastsRepository : Repository<WeatherForecast, WeatherForecastContrib, int>,
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

            var forecasts = await Connection.QueryAsync<WeatherForecastContrib>(cmd);

            return forecasts
                .Select(MapContribToEntity)
                .ToList();
        }

        protected override WeatherForecastContrib MapEntityToContrib(WeatherForecast entity)
        {
            return new WeatherForecastContrib
            {
                Id = entity.Id,
                Date = entity.Date,
                Summary = entity.Summary.Text,
                TemperatureC = entity.TemperatureC
            };
        }

        protected override WeatherForecast MapContribToEntity(WeatherForecastContrib contrib)
        {
            return new WeatherForecast(contrib.Id)
                .SetDate(contrib.Date)
                .SetSummary(contrib.Summary)
                .SetCelciusTemperature(contrib.TemperatureC);
        }

        protected override void SetContribId(WeatherForecastContrib contrib, int id)
        {
            contrib.Id = id;
        }
    }
}