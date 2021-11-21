using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IRepository<TEntity, TId> where TEntity : EntityBase<TId>
    {
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}