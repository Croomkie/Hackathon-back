using Hackathon.DTOs;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Core.Interfaces
{
    public interface IImageEvenementService : ICRUDService<ImageEvenementDTO>
    {
        Task UpdateImageEvenement(int evenementId, IFormFileCollection imageFiles);
    }
}
