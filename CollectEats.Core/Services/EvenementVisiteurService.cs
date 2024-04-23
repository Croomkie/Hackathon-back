using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class EvenementVisiteurService(IRepository<EvenementVisiteur> repository, IMapper mapper) : CRUDService<EvenementVisiteur, EvenementVisiteurDTO>(repository, mapper), IEvenementVisiteurService
    {
    }
}
