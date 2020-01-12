using System.Threading.Tasks;
using AprovationCenter.Domain.Core.Commands;
using AprovationCenter.Domain.Core.Events;

namespace AprovationCenter.Domain.Core.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
