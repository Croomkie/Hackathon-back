using Hackathon.Shared.Enum;

namespace Hackathon.Data.Models
{
    public class EvenementVisiteur
    {
        public int EvenementId { get; set; }
        public int VisiteurId { get; set; }
        public Status Status { get; set; }
    }
}
