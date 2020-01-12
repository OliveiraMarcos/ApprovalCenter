using ApprovalCenter.Domain.Core.Events;

namespace ApprovalCenter.Domain.Core.Interfaces.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
