using System.Threading.Tasks;

namespace AprovationCenter.Infra.CrossCutting.Identity.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
