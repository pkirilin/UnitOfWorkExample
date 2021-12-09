using Dapper.Contrib.Extensions;

namespace UnitOfWorkExample.Infrastructure.Dapper
{
    public class ContribBase<TId>
    {
        [Key]
        public TId Id { get; set; } = default!;
    }
}