namespace Hackathon.DTOs
{
    public class ImageDTO
    {
        public int ImageId { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public int AtelierId { get; set; }
    }
}
