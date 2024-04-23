using Hackathon.DTOs;

namespace Hackathon.Core.Interfaces
{
    public interface IVisiteurService : ICRUDService<VisiteurDTO>
    {
        Task<IList<string>> ListeEmailVisiteurEvenement(int evenementId);
    }
}
