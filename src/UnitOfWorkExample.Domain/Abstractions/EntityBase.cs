namespace UnitOfWorkExample.Domain.Abstractions
{
    public class EntityBase<TId>
    {
        public TId Id { get; set; }
    }
}