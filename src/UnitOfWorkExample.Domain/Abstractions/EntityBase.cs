using System;

namespace UnitOfWorkExample.Domain.Abstractions
{
    public abstract class EntityBase<TId> where TId : IComparable<TId>
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