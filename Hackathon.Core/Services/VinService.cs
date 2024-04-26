using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class VinService(IRepository<Vin> repository, IMapper mapper) : CRUDService<Vin, VinDTO>(repository, mapper), IVinService
    {
    }
}
