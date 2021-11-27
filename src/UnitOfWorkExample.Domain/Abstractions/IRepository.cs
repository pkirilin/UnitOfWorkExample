using System.Threading;
using System.Threading.Tasks;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IRepository<TEntity, in TId> where TEntity : EntityBase<TId>
    {
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken);
        
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}