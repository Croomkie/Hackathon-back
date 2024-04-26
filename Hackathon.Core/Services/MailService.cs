using Hackathon.Core.Interfaces;
using Hackathon.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Hackathon.Core.Services
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(MailDTO mailDTO, string email, string password)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Hackathon Wine", "wine.hackathon@wine.com"));
            foreach (var emailTo in mailDTO.EmailsTo)
                emailMessage.To.Add(new MailboxAddress("", emailTo));
            emailMessage.Subject = mailDTO.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = mailDTO.HtmlContent };

            // Vérifiez et ajoutez la pièce jointe avant de définir le corps du message
            if (mailDTO.Attachment != null)
            {
                using (var ms = new MemoryStream())
                {
                    mailDTO.Attachment.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    bodyBuilder.Attachments.Add(mailDTO.Attachment.FileName, fileBytes, ContentType.Parse(mailDTO.Attachment.ContentType));
                }
            }

            // Assignez le corps du message après avoir ajouté toutes les pièces jointes
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable);
            await client.AuthenticateAsync(email, password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
