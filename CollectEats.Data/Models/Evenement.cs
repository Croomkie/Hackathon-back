namespace Hackathon.Data.Models
{
    public class Evenement
    {
        public int EvenementId { get; set; }
        public string EvenementName { get; set; } = string.Empty;
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public string DateLimit { get; set; } = string.Empty;
        public string Localisation { get; set; } = string.Empty;
        public int NombreParticipant { get; set; }
        public int NombreDegustation { get; set; }
        public decimal Prix { get; set; }

        //Relation
        public int? EcoleId { get; set; }
        public Ecole? Ecole { get; set; }

        public int AtelierId { get; set; }
        public Atelier? Atelier { get; set; }

        public virtual ICollection<Visiteur>? Visiteur { get; set; }
    }
}
