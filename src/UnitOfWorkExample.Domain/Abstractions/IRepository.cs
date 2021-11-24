namespace UnitOfWorkExample.Domain.Abstractions
{
    public interface IRepository<TEntity, TId> where TEntity : EntityBase<TId>
    {
        TEntity Add(TEntity entity);
    }
}