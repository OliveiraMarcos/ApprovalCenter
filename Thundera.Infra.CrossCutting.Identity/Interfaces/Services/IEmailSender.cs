using System.Threading.Tasks;

namespace Thundera.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
