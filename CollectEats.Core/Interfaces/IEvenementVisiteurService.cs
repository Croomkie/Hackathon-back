﻿using Hackathon.DTOs;

namespace Hackathon.Core.Interfaces
{
    public interface IEvenementVisiteurService : ICRUDService<EvenementVisiteurDTO>
    {
        Task<IEnumerable<EvenementVisiteurDTO>> GetEvenementVisiteur();
    }
}
