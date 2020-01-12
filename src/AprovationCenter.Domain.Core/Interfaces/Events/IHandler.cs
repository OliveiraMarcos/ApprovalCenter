using AprovationCenter.Domain.Core.Events;

namespace AprovationCenter.Domain.Core.Interfaces.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
