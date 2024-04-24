using Microsoft.AspNetCore.Http;

namespace Hackathon.DTOs
{
    public class AddEvenementDTO
    {
        public string EvenementName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public string DateLimit { get; set; } = string.Empty;
        public string Localisation { get; set; } = string.Empty;
        public int NombreParticipant { get; set; }
        public int NombreDegustation { get; set; }
        public decimal Prix { get; set; }

        //Relation
        public int AtelierId { get; set; }
        public int? EcoleId { get; set; }
        public IFormFileCollection? ImageFiles { get; set; }
    }
}
