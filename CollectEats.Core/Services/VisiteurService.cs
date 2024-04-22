using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class VisiteurService(IRepository<Visiteur> repository, IMapper mapper) : CRUDService<Visiteur, VisiteurDTO>(repository, mapper), IVisiteurService
    {
    }
}
