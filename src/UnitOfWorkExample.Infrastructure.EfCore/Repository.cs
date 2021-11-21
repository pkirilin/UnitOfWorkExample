using System.Collections.Generic;
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
        
        public Task<List<TEntity>> GetAsync(CancellationToken cancellationToken)
        {
            return Entities.ToListAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var entry = await Entities.AddAsync(entity, cancellationToken);
            return entry.Entity;
        }
    }
}