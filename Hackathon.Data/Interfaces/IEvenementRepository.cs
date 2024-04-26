using Hackathon.Data.Models;
using Hackathon.Shared.Enum;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Data.Interfaces
{
    public interface IEvenementRepository
    {
        Task<IEnumerable<Evenement>> GetEvenement();
        Task<IEnumerable<EvenementVisiteur>> GetEvenementVisiteur();
        Task CreateEvenementWithImage(Evenement evenement, IFormFileCollection? images);
        Task CreateEvenementVisiteur(string email, int evenementId, int? ecoleId);
        Task UpdateEvenementVisiteur(int evenementId, int visiteurId, Status status);
        Task UpdateEvenementWithImage(int id, Evenement evenement, IFormFileCollection? images);
    }
}
