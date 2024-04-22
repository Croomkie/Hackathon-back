namespace Hackathon.DTOs
{
    public class VisiteurDTO
    {
        public int VisiteurId { get; set; }
        public string Email { get; set; } = string.Empty;

        //Relation
        public EcoleDTO? Ecole { get; set; }
    }
}
