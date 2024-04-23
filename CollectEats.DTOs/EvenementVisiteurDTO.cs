using Hackathon.Shared.Enum;

namespace Hackathon.DTOs
{
    public class EvenementVisiteurDTO
    {
        public int EvenementId { get; set; }
        public int VisiteurId { get; set; }
        public Status Status { get; set; }
    }
}
