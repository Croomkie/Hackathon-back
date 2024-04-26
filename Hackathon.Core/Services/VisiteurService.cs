using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class VisiteurService(IRepository<Visiteur> repository, IMapper mapper, IVisiteurRepository visiteurRepository) : CRUDService<Visiteur, VisiteurDTO>(repository, mapper), IVisiteurService
    {
        private readonly IVisiteurRepository _visiteurRepository = visiteurRepository;

        public async Task<IList<string>> ListeEmailVisiteurEvenement(int evenementId)
        {
            return await _visiteurRepository.ListeEmailVisiteurEvenement(evenementId);
        }
    }
}
