using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAsync(CancellationToken cancellationToken);
    }
}