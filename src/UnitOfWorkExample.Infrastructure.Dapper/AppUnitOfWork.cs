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
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _isDisposed;

        private IWeatherForecastsRepository _weatherForecastsRepository;

        public AppUnitOfWork(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration["ConnectionStrings:MySql"]);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _weatherForecastsRepository = new WeatherForecastsRepository(_connection, _transaction);
        }
        
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Task.CompletedTask;

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
                ResetRepositories();
            }
            
            return Task.CompletedTask;
        }

        public IWeatherForecastsRepository WeatherForecasts
        {
            get
            {
                if (_weatherForecastsRepository == null)
                {
                    _weatherForecastsRepository = new WeatherForecastsRepository(_connection, _transaction);
                    return _weatherForecastsRepository;
                }

                return _weatherForecastsRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        ~AppUnitOfWork()
        {
            Dispose(false);
        }
        
        private void ResetRepositories()
        {
            _weatherForecastsRepository = null;
        }
        
        private void Dispose(bool isDisposing)
        {
            if (_isDisposed)
                return;

            if (isDisposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }

            _isDisposed = true;
        }
    }
}