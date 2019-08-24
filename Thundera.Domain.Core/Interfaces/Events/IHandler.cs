using Thundera.Domain.Core.Events;

namespace Thundera.Domain.Core.Interfaces.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
