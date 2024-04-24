using Hackathon.DTOs;

namespace Hackathon.Core.Interfaces
{
    public interface IEvenementService : ICRUDService<EvenementDTO>
    {
        Task<IEnumerable<EvenementDTO>> GetEvenements();
    }
}
