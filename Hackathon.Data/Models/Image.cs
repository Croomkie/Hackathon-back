namespace Hackathon.Data.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;

        // Clé étrangère pour Atelier
        public int AtelierId { get; set; }
        public virtual Atelier? Atelier { get; set; }
    }
}
