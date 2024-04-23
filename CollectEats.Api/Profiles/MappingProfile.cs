using AutoMapper;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace CollectEats.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /***** Mappage pour Atelier *****/
            CreateMap<Atelier, AtelierDTO>();
            CreateMap<AtelierDTO, Atelier>();

            /***** Mappage pour Ecole *****/
            CreateMap<Ecole, EcoleDTO>();
            CreateMap<EcoleDTO, Ecole>();

            /***** Mappage pour Evenement *****/
            CreateMap<Evenement, EvenementDTO>();
            CreateMap<EvenementDTO, Evenement>();

            /***** Mappage pour EvenementVisiteur *****/
            CreateMap<EvenementVisiteur, EvenementVisiteurDTO>();
            CreateMap<EvenementVisiteurDTO, EvenementVisiteur>();

            /***** Mappage pour Vin *****/
            CreateMap<Vin, VinDTO>();
            CreateMap<VinDTO, Vin>();

            /***** Mappage pour Utilisateur *****/
            CreateMap<Utilisateur, UtilisateurDTO>();
            CreateMap<UtilisateurDTO, Utilisateur>();

            /***** Mappage pour Visiteur *****/
            CreateMap<Visiteur, VisiteurDTO>();
            CreateMap<VisiteurDTO, Visiteur>();
        }
    }
}
