using Hackathon.Shared.Enum;

namespace Hackathon.Data.Models
{
    public class AtelierVisiteur
    {
        public int AtelierId { get; set; }
        public int VisiteurId { get; set; }
        public Status Status { get; set; }
    }
}
