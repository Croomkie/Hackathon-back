using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Core.Services
{
    public class ImageEvenementService(IRepository<ImageEvenement> repository, IMapper mapper, IAtelierRepository atelierRepository) : CRUDService<ImageEvenement, ImageEvenementDTO>(repository, mapper), IImageEvenementService
    {
        private readonly IAtelierRepository _atelierRepository = atelierRepository;

        public async Task UpdateImageEvenement(int evenementId, IFormFileCollection imageFiles)
        {
            await _atelierRepository.UpdateImageEvenement(evenementId, imageFiles);
        }
    }
}
