namespace Hackathon.Data.Models
{
    public class Atelier
    {
        public int AtelierId { get; set; }
        public string AtelierName { get; set; } = string.Empty;
        public string Thematique { get; set; } = string.Empty;
        public string Ressource { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;

        //Relation
        public string? UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }
    }
}
