using System;
using System.Collections.Generic;
using System.Text;

namespace Tesla.Elegance.Domain.Abstractions
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }
    }
}
