namespace Hackathon.DTOs
{
    public class VinDTO
    {
        public int VinId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Millesime { get; set; } = string.Empty;
        public string Cepage { get; set; } = string.Empty;
        public string Annotation { get; set; } = string.Empty;
        public int Quatite { get; set; }
    }
}
