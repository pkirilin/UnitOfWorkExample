using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;

namespace UnitOfWorkExample.Infrastructure.Dapper.Repositories
{
    internal class WeatherForecastsRepository : IWeatherForecastsRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public WeatherForecastsRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        
        public Task<WeatherForecast> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public WeatherForecast Add(WeatherForecast entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(WeatherForecast entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(WeatherForecast entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<WeatherForecast>> GetForecastsAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}