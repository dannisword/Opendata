using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opendata.Infrastructure
{
    public class EmailSender : ISender
    {
        public async Task<int> SendAsync(string toEmail, string subject, string message)
        {
            var mmsg = new MimeMessage();
            var fromEmail = "dannis.word@gmail.com";
            mmsg.From.Add(new MailboxAddress("dannis", fromEmail));
            mmsg.To.Add(new MailboxAddress("收信者", toEmail));
            mmsg.Subject = subject;
            mmsg.Body = new TextPart("html") { Text = message };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
              
                client.Authenticate(fromEmail, "zvymipypfgsnngme");
                await client.SendAsync(mmsg).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
            return 0;
        }
    }
    public interface ISender
    {
        Task<int> SendAsync(string email, string subject, string message);
    }
}