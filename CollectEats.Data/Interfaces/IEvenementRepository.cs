using Hackathon.Data.Models;

namespace Hackathon.Data.Interfaces
{
    public interface IEvenementRepository
    {
        Task<IEnumerable<Evenement>> GetEvenement();
        Task<IEnumerable<EvenementVisiteur>> GetEvenementVisiteur();
    }
}
