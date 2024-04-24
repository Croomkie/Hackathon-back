using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class ImageEvenementService(IRepository<ImageEvenement> repository, IMapper mapper) : CRUDService<ImageEvenement, ImageEvenementDTO>(repository, mapper), IImageEvenementService
    {
    }
}
