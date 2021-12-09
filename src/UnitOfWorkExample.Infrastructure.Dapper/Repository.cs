using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    internal abstract class Repository<TEntity, TContrib, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TContrib : ContribBase<TId>
        where TId : IComparable<TId>
    {
        protected readonly IDbConnection Connection;
        protected readonly IDbTransaction Transaction;

        protected Repository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
        
        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var contrib = await Connection.GetAsync<TContrib>(id, transaction: Transaction);
            return MapContribToEntity(contrib);
        }

        public TEntity Add(TEntity entity)
        {
            var contrib = MapEntityToContrib(entity);
            Connection.Insert(contrib, transaction: Transaction);
            contrib.Id = Connection.ExecuteScalar<TId>("select LAST_INSERT_ID()", transaction: Transaction);
            return MapContribToEntity(contrib);
        }

        public void Update(TEntity entity)
        {
            var contrib = MapEntityToContrib(entity);
            Connection.Update(contrib, transaction: Transaction);
        }

        public void Remove(TEntity entity)
        {
            var contrib = MapEntityToContrib(entity);
            Connection.Delete(contrib, transaction: Transaction);
        }

        protected abstract TContrib MapEntityToContrib(TEntity entity);
        protected abstract TEntity MapContribToEntity(TContrib contrib);
    }
}