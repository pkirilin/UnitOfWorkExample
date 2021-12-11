using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using UnitOfWorkExample.Domain.Abstractions;
using UnitOfWorkExample.Domain.Entities;
using UnitOfWorkExample.Domain.Repositories;

namespace UnitOfWorkExample.Infrastructure.NHibernate.Repositories
{
    public class WeatherForecastsRepository<TEntity, TId> : Repository<TEntity, TId>, IWeatherForecastsRepository
        where TEntity : EntityBase<TId>
        where TId : IComparable<TId>
    {
        public WeatherForecastsRepository(ISession session) : base(session)
        {
        }
        
        public Task<WeatherForecast> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public WeatherForecast Add(WeatherForecast entity)
        {
            throw new NotImplementedException();
        }

        public void Update(WeatherForecast entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(WeatherForecast entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<WeatherForecast>> GetForecastsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}