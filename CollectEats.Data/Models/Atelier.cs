namespace Hackathon.Data.Models
{
    public class Atelier
    {
        public int AtelierId { get; set; }
        public string AtelierName { get; set; } = string.Empty;
        public string Date_start { get; set; } = string.Empty;
        public string Date_End { get; set; } = string.Empty;
        public string Date_limit { get; set; } = string.Empty;
        public int Nombre_participant { get; set; }
        public string Thematique { get; set; } = string.Empty;
        public string Ressource { get; set; } = string.Empty;

        //Relation
        public string? UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public int? EcoleId { get; set; }
        public Ecole? Ecole { get; set; }
        public virtual ICollection<Visiteur>? Visiteur { get; set; }
    }
}
