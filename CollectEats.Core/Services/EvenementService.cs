using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class EvenementService(IRepository<Evenement> repository, IMapper mapper, IEvenementRepository evenementRepository) : CRUDService<Evenement, EvenementDTO>(repository, mapper), IEvenementService
    {
        private readonly IEvenementRepository _evenementRepository = evenementRepository;

        public async Task<IEnumerable<EvenementDTO>> GetEvenements()
        {
            return _mapper.Map<IEnumerable<EvenementDTO>>(await _evenementRepository.GetEvenement());
        }

        public async Task CreateEvenementWithImage(AddEvenementDTO addEvenementDTO)
        {
            var evenement = _mapper.Map<Evenement>(addEvenementDTO);
            await _evenementRepository.CreateEvenementWithImage(evenement, addEvenementDTO.ImageFiles);
        }
    }
}
