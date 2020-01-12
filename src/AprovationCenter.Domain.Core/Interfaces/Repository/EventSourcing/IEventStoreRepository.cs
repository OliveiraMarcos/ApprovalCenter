using System;
using System.Collections.Generic;
using AprovationCenter.Domain.Core.Events;

namespace AprovationCenter.Domain.Core.Interfaces.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
