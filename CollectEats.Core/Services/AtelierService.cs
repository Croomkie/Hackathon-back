using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Core.Services
{
    //(IRepository<Adresse> repository, IMapper mapper, IAdresseRepository adresseRepository) : CRUDService<Adresse, AdresseDTO>(repository, mapper), IAdresseService
    public class AtelierService(IRepository<Atelier> repository, IMapper mapper, IAtelierRepository atelierRepository) : CRUDService<Atelier, AtelierDTO>(repository, mapper), IAtelierService
    {
        private readonly IAtelierRepository _atelierRepository = atelierRepository;

        public async Task<IEnumerable<EvenementDTO>> GetEvenementAtelier(int atelierId)
        {
            return _mapper.Map<IEnumerable<EvenementDTO>>(await _atelierRepository.GetEvenementAtelier(atelierId));
        }

        public async Task UpdateImageAtelier(int atelierId, IFormFileCollection images)
        {
            await _atelierRepository.UpdateImageAtelier(atelierId, images);
        }
    }
}
