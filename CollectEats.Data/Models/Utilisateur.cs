using Microsoft.AspNetCore.Identity;

namespace Hackathon.Data.Models
{
    public class Utilisateur : IdentityUser
    {
        public string? Telephone { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
    }
}
