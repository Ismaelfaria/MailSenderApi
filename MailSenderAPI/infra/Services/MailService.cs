using System.Net;
using System.Net.Mail;

namespace MailSenderAPI.infra.Services
{
    public class MailService : IMailService
    {
        private string smtpAddress => "smtp.gmail.com";
        private int portNumber => 587;
        private string emailFromAddress => "limaismael8901@gmail.com";
        private string password => "idme fklj regw cfkj";

        public void AddEmailsToMailmensager(MailMessage mailMessage, string[] emails)
        {
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }

        public void SendEmail(string[] emails, string subject, string body, bool isHtml = false)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(emailFromAddress);
                AddEmailsToMailmensager(mailMessage, emails);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;

                using(SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.Send(mailMessage);
                } 
            }
        }

    }
}
