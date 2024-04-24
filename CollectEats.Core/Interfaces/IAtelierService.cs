using Hackathon.DTOs;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Core.Interfaces
{
    public interface IAtelierService : ICRUDService<AtelierDTO>
    {
        Task UpdateImageAtelier(int atelierId, IFormFileCollection images);
        Task<IEnumerable<EvenementDTO>> GetEvenementAtelier(int atelierId);
    }
}
