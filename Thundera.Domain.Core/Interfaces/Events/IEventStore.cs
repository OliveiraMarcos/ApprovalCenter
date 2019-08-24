using Thundera.Domain.Core.Events;

namespace Thundera.Domain.Core.Interfaces.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
