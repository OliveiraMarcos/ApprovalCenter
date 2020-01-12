using System.Threading.Tasks;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
