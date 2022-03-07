using Dddify.Domain.Events;
using System;
using System.Collections.Generic;

namespace Dddify.Domain.Entities
{
    [Serializable]
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        
    }
}
