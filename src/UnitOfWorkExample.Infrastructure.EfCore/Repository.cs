using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : EntityBase<TId>
    {
        protected readonly DbSet<TEntity> Entities;

        protected Repository(DbSet<TEntity> entities)
        {
            Entities = entities;
        }

        public Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            var entry = Entities.Add(entity);
            return entry.Entity;
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}