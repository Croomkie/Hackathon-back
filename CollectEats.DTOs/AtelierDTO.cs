namespace Hackathon.DTOs
{
    public class AtelierDTO
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
        public EcoleDTO? Ecole { get; set; }
    }
}
