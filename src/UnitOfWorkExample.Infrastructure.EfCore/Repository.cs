using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Domain.Abstractions;

namespace UnitOfWorkExample.Infrastructure.EfCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
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
    }
}