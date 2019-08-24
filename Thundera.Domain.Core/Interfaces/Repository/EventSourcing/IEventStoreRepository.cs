using System;
using System.Collections.Generic;
using Thundera.Domain.Core.Events;

namespace Thundera.Domain.Core.Interfaces.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
