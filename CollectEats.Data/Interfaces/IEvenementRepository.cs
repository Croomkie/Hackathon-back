using Hackathon.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Data.Interfaces
{
    public interface IEvenementRepository
    {
        Task<IEnumerable<Evenement>> GetEvenement();
        Task<IEnumerable<EvenementVisiteur>> GetEvenementVisiteur();
        Task CreateEvenementWithImage(Evenement evenement, IFormFileCollection? images);
    }
}
