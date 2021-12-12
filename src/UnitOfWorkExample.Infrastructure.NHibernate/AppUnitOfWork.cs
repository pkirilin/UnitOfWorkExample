using System;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Repositories;
using UnitOfWorkExample.Infrastructure.NHibernate.Repositories;

namespace UnitOfWorkExample.Infrastructure.NHibernate
{
    public class AppUnitOfWork : IAppUnitOfWork, IDisposable
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public AppUnitOfWork(ISessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
            WeatherForecasts = new WeatherForecastsRepository(_session);
        }
        
        public IWeatherForecastsRepository WeatherForecasts { get; private set; }
        
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await _transaction.RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _session.BeginTransaction();
                WeatherForecasts = new WeatherForecastsRepository(_session);
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _session.Dispose();
        }
    }
}