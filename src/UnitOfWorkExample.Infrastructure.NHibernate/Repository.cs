using System;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.NHibernate
{
    public abstract class Repository<TDomainEntity, TPersistentEntity, TId> : IRepository<TDomainEntity, TId>
        where TDomainEntity : EntityBase<TId>
        where TId : IComparable<TId>
    {
        protected readonly ISession Session;

        protected Repository(ISession session)
        {
            Session = session;
        }
        
        public Task<TDomainEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public TDomainEntity Add(TDomainEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TDomainEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TDomainEntity entity)
        {
            throw new NotImplementedException();
        }
        
        protected abstract TDomainEntity MapToDomainEntity(TPersistentEntity entity);
        protected abstract TPersistentEntity MapToPersistentEntity(TDomainEntity entity);
    }
}