using Hackathon.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Data.Interfaces
{
    public interface IAtelierRepository
    {
        Task UpdateImageAtelier(int atelierId, IFormFileCollection images);
        Task UpdateImageEvenement(int evenementId, IFormFileCollection images);
        Task<IEnumerable<Evenement>> GetEvenementAtelier(int atelierId);
        Task CreateAtelierWithImage(Atelier atelier, IFormFileCollection? images);
    }
}
