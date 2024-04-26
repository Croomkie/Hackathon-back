namespace Hackathon.DTOs
{
    public class AtelierDTO
    {
        public int AtelierId { get; set; }
        public string AtelierName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Thematique { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Ressource { get; set; } = string.Empty;
        public IList<ImageDTO>? Image { get; set; }
    }
}
