using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class HomeDescriptionService(IRepository<HomeDescription> repository, IMapper mapper) : CRUDService<HomeDescription, HomeDescriptionDTO>(repository, mapper), IHomeDescriptionService
    {
    }
}
