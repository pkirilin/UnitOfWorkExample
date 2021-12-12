using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Repositories;
using UnitOfWorkExample.Infrastructure.Dapper.Repositories;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    internal class AppUnitOfWork : IAppUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        
        public IWeatherForecastsRepository WeatherForecasts { get; private set; }

        public AppUnitOfWork(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration["ConnectionStrings:MySql"]);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            WeatherForecasts = new WeatherForecastsRepository(_connection, _transaction);
        }
        
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                WeatherForecasts = new WeatherForecastsRepository(_connection, _transaction);
            }
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _connection.Dispose();
        }
    }
}