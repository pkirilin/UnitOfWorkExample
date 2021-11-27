namespace UnitOfWorkExample.Domain.Abstractions
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; }

        protected EntityBase()
        {
        }

        protected EntityBase(TId id)
        {
            Id = id;
        }
    }
}