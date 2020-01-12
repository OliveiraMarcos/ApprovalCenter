using System.Threading.Tasks;

namespace AprovationCenter.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
