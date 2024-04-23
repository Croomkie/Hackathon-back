using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class EvenementService(IRepository<Evenement> repository, IMapper mapper) : CRUDService<Evenement, EvenementDTO>(repository, mapper), IEvenementService
    {

    }
}
