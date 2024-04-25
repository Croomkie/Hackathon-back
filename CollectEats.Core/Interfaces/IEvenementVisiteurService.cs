using Hackathon.DTOs;
using Hackathon.Shared.Enum;

namespace Hackathon.Core.Interfaces
{
    public interface IEvenementVisiteurService : ICRUDService<EvenementVisiteurDTO>
    {
        Task<IEnumerable<EvenementVisiteurDTO>> GetEvenementVisiteur();
        Task CreateEvenementVisiteur(string email, int evenementId, int? ecoleId);
        Task UpdateEvenementVisiteur(int evenementId, int visiteurId, Status status);
    }
}
