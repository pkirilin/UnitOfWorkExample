using System.Threading;
using System.Threading.Tasks;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}