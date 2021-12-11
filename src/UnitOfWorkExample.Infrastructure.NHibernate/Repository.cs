using System;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.NHibernate
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : IComparable<TId>
    {
        protected readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }
        
        public Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}