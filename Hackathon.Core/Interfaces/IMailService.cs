using Hackathon.DTOs;

namespace Hackathon.Core.Interfaces
{
    public interface IMailService
    {
        Task SendMailAsync(MailDTO mailDTO, string email, string password);
    }
}
