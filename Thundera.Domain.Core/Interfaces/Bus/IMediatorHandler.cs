using System.Threading.Tasks;
using Thundera.Domain.Core.Commands;
using Thundera.Domain.Core.Events;

namespace Thundera.Domain.Core.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
