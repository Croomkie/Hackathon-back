namespace Hackathon.DTOs
{
    public class ImageEvenementDTO
    {
        public int ImageEvenementId { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public int EvenementId { get; set; }
    }
}
