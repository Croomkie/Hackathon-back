using Microsoft.AspNetCore.Http;

namespace Hackathon.DTOs
{
    public class MailDTO
    {
        public required IList<string> EmailsTo { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string HtmlContent { get; set; } = string.Empty;
        public IFormFile? Attachment { get; set; }
    }
}
