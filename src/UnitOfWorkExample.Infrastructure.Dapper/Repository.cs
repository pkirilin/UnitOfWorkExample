using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    internal abstract class Repository<TDomainEntity, TPersistentEntity, TId> : IRepository<TDomainEntity, TId>
        where TDomainEntity : EntityBase<TId>
        where TPersistentEntity : class
        where TId : IComparable<TId>
    {
        protected readonly IDbConnection Connection;
        protected readonly IDbTransaction Transaction;

        protected static readonly string TableName = ReflectionHelper.GetTableName<TPersistentEntity>();

        protected Repository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
        
        public async Task<TDomainEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            var persistentEntity = await Connection.GetAsync<TPersistentEntity>(id, transaction: Transaction);
            return (persistentEntity == null ? null : MapToDomainEntity(persistentEntity))!;
        }

        public TDomainEntity Add(TDomainEntity entity)
        {
            var persistentEntity = MapToPersistentEntity(entity);
            Connection.Insert(persistentEntity, transaction: Transaction);
            var id = Connection.ExecuteScalar<TId>("select LAST_INSERT_ID()", transaction: Transaction);
            SetPersistentEntityId(persistentEntity, id);
            return MapToDomainEntity(persistentEntity);
        }

        public void Update(TDomainEntity entity)
        {
            var persistentEntity = MapToPersistentEntity(entity);
            Connection.Update(persistentEntity, transaction: Transaction);
        }

        public void Remove(TDomainEntity entity)
        {
            var persistentEntity = MapToPersistentEntity(entity);
            Connection.Delete(persistentEntity, transaction: Transaction);
        }

        protected abstract TPersistentEntity MapToPersistentEntity(TDomainEntity entity);
        
        protected abstract TDomainEntity MapToDomainEntity(TPersistentEntity entity);

        protected abstract void SetPersistentEntityId(TPersistentEntity entity, TId id);
    }
}