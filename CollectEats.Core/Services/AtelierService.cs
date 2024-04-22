using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    //(IRepository<Adresse> repository, IMapper mapper, IAdresseRepository adresseRepository) : CRUDService<Adresse, AdresseDTO>(repository, mapper), IAdresseService
    public class AtelierService(IRepository<Atelier> repository, IMapper mapper) : CRUDService<Atelier, AtelierDTO>(repository, mapper), IAtelierService
    {
    }
}
