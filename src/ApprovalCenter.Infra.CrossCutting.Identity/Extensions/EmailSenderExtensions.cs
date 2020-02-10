using System.Text.Encodings.Web;
using ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services;
using System.Threading.Tasks;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        public static Task SendEmailForgotPasswordAsync(this IEmailSender emailSender, string email, string link)
        {
            //$"Please reset your password by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>"
            return emailSender.SendEmailAsync(email, "Reset Password",
                $"Please use this code of security for reset your password: {link}");
        }
    }
}
