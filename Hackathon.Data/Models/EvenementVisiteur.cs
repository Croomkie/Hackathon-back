using Hackathon.Shared.Enum;

namespace Hackathon.Data.Models
{
    public class EvenementVisiteur
    {
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; } = null!;
        public int VisiteurId { get; set; }
        public Visiteur Visiteur { get; set; } = null!;
        public Status Status { get; set; }
    }
}
