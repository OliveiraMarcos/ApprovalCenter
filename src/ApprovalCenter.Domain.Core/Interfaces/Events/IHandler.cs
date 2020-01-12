using ApprovalCenter.Domain.Core.Events;

namespace ApprovalCenter.Domain.Core.Interfaces.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
