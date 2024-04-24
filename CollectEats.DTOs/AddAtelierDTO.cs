using Microsoft.AspNetCore.Http;

namespace Hackathon.DTOs
{
    public class AddAtelierDTO
    {
        public string AtelierName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Thematique { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Ressource { get; set; } = string.Empty;
        public IFormFileCollection? ImageFiles { get; set; }
    }
}
