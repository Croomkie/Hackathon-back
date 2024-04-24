namespace Hackathon.Data.Models
{
    public class ImageEvenement
    {
        public int ImageEvenementId { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;

        // Clé étrangère pour Atelier
        public int EvenementId { get; set; }
        public virtual Evenement? Evenement { get; set; }
    }
}
