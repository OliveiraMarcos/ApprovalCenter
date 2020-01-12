using System.Threading.Tasks;
using AprovationCenter.Infra.CrossCutting.Identity.Interfaces.Services;

namespace AprovationCenter.Infra.CrossCutting.Identity.Services
{
    public class AuthSMSMessageSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
