namespace Hackathon.DTOs
{
    public class VisiteurDTO
    {
        public int VisiteurId { get; set; }
        public string Email { get; set; } = string.Empty;

        //Relation
        public int? EcoleId { get; set; }
        public EcoleDTO? Ecole { get; set; }
    }
}
