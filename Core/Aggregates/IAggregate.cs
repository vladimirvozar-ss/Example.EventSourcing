using Core.Events;
using System;
using System.Collections.Generic;

namespace Core.Aggregates
{
    public interface IAggregate
    {
        Guid Id { get; }
        int Version { get; }

        IEnumerable<IEvent> DequeueUncommittedEvents();
    }
}
