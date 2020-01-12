using System;
using System.Collections.Generic;
using ApprovalCenter.Domain.Core.Events;

namespace ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
