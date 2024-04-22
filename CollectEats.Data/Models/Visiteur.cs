using Hackathon.Shared.Enum;

namespace Hackathon.Data.Models
{
    public class Visiteur
    {
        public int VisiteurId { get; set; }
        public string Email { get; set; } = string.Empty;

        //Relation
        public virtual ICollection<Atelier>? Atelier { get; set; }
    }
}
