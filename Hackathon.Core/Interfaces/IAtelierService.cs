﻿using Hackathon.Data.Models;
using Hackathon.DTOs;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Core.Interfaces
{
    public interface IAtelierService : ICRUDService<AtelierDTO>
    {
        Task UpdateImageAtelier(int atelierId, IFormFileCollection images);
        Task<IEnumerable<EvenementDTO>> GetEvenementAtelier(int atelierId);
        Task CreateAtelierWithImage(AddAtelierDTO atelierDto);
        Task UpdateAtelierWithImage(int id, AddAtelierDTO atelierDto);
    }
}
