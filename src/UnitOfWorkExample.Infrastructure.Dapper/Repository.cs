using System;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    internal class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : IComparable<TId>
    {
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