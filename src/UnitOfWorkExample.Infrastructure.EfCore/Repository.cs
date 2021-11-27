using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    internal class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : EntityBase<TId>
        where TId : IComparable<TId>
    {
        protected readonly DbSet<TEntity> Entities;

        protected Repository(DbSet<TEntity> entities)
        {
            Entities = entities;
        }

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return await Entities.FirstOrDefaultAsync(e => e.Id.CompareTo(id) == 0, cancellationToken);
        }

        public TEntity Add(TEntity entity)
        {
            var entry = Entities.Add(entity);
            return entry.Entity;
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}