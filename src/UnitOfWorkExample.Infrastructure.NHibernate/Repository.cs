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
        
        public async Task<TDomainEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            var entity = await Session.GetAsync<TPersistentEntity>(id, cancellationToken);
            return MapToDomainEntity(entity);
        }

        public TDomainEntity Add(TDomainEntity entity)
        {
            var persistentEntity = MapToPersistentEntity(entity);
            var id = (TId)Session.Save(persistentEntity);
            SetPersistentEntityId(persistentEntity, id);
            return MapToDomainEntity(persistentEntity);
        }

        public void Update(TDomainEntity entity)
        {
            var persistentEntity = MapToPersistentEntity(entity);
            Session.Merge(persistentEntity);
        }

        public void Remove(TDomainEntity entity)
        {
            var persistentEntity = Session.Get<TPersistentEntity>(entity.Id);
            Session.Delete(persistentEntity);
        }
        
        protected abstract TDomainEntity MapToDomainEntity(TPersistentEntity entity);
        protected abstract TPersistentEntity MapToPersistentEntity(TDomainEntity entity);
        protected abstract void SetPersistentEntityId(TPersistentEntity entity, TId id);
    }
}