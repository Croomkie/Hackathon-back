using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Core.Services
{
    public class ImageService(IRepository<Image> repository, IMapper mapper) : CRUDService<Image, ImageDTO>(repository, mapper), IImageService
    {
    }
}
