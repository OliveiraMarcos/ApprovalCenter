using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Services
{
    public class AuthEmailMessageSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; }
        public AuthEmailMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Execute(subject, message, email);
        }
        public Task Execute(string subject, string message, string email)
        {
            var msg = new MailMessage()
            {
                From = new MailAddress(Options.UserCredential, Options.UserCredential),
                Subject = subject
            };
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html));

            msg.To.Add(new MailAddress(email));


            var credentials = new NetworkCredential(
                 Options.UserCredential,
                 Options.PassCredential
                 );
            // Create a Web transport for sending email.
            var smtpClient = new SmtpClient(Options.SmptHost,Options.SmptPort);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = Options.EnableSsl;

            // Send the email.
            if (smtpClient != null)
            {
                return smtpClient.SendMailAsync(msg);
            }
            else
            {
                return Task.FromResult(0);
            }
        }
    }
}
