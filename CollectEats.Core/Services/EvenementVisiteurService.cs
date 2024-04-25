using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class EvenementVisiteurService(IRepository<EvenementVisiteur> repository, IMapper mapper, IEvenementRepository evenementRepository) : CRUDService<EvenementVisiteur, EvenementVisiteurDTO>(repository, mapper), IEvenementVisiteurService
    {
        private readonly IEvenementRepository _evenementRepository = evenementRepository;

        public async Task CreateEvenementVisiteur(string email, int evenementId, int? ecoleId)
        {
            await _evenementRepository.CreateEvenementVisiteur(email, evenementId, ecoleId);
        }

        public async Task<IEnumerable<EvenementVisiteurDTO>> GetEvenementVisiteur()
        {
            return _mapper.Map<IEnumerable<EvenementVisiteurDTO>>(await _evenementRepository.GetEvenementVisiteur());
        }
    }
}
