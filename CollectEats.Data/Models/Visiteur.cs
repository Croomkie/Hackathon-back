namespace Hackathon.Data.Models
{
    public class Visiteur
    {
        public int VisiteurId { get; set; }
        public string Email { get; set; } = string.Empty;

        //Relation
        public int? EcoleId { get; set; }
        public Ecole? Ecole { get; set; }
        public virtual ICollection<Atelier>? Atelier { get; set; }
    }
}
