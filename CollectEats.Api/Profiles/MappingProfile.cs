using AutoMapper;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace CollectEats.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /***** Mappage pour Utilisateur *****/
            CreateMap<Utilisateur, UtilisateurDTO>();
            CreateMap<UtilisateurDTO, Utilisateur>();
        }
    }
}
