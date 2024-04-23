using Microsoft.AspNetCore.Http;

namespace Hackathon.Data.Interfaces
{
    public interface IAtelierRepository
    {
        Task UpdateImageAtelier(int atelierId, IFormFileCollection images);
    }
}
