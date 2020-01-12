using System.Threading.Tasks;
using ApprovalCenter.Domain.Core.Commands;
using ApprovalCenter.Domain.Core.Events;

namespace ApprovalCenter.Domain.Core.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
