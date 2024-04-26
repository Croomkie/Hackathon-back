using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class EcoleService(IRepository<Ecole> repository, IMapper mapper) : CRUDService<Ecole, EcoleDTO>(repository, mapper), IEcoleService
    {
    }
}
