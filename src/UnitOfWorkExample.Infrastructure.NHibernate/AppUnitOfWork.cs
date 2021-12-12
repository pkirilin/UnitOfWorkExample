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
        private readonly ITransaction _transaction;

        public AppUnitOfWork(ISessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
            WeatherForecasts = new WeatherForecastsRepository(_session);
        }
        
        public IWeatherForecastsRepository WeatherForecasts { get; }
        
        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _transaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _session.Dispose();
        }
    }
}