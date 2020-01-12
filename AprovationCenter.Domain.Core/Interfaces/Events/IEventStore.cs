using AprovationCenter.Domain.Core.Events;

namespace AprovationCenter.Domain.Core.Interfaces.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
