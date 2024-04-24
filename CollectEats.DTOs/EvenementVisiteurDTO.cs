using Hackathon.Shared.Enum;

namespace Hackathon.DTOs
{
    public class EvenementVisiteurDTO
    {
        public int EvenementId { get; set; }
        public EvenementDTO Evenement { get; set; } = null!;
        public int VisiteurId { get; set; }
        public VisiteurDTO Visiteur { get; set; } = null!;
        public Status Status { get; set; }
    }
}
