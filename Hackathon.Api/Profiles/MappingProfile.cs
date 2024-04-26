using AutoMapper;
using Hackathon.Data.Models;
using Hackathon.DTOs;

namespace Hackathon.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /***** Mappage pour Atelier *****/
            CreateMap<Atelier, AtelierDTO>();
            CreateMap<AtelierDTO, Atelier>();

            /***** Mappage pour Atelier *****/
            CreateMap<HomeDescription, HomeDescriptionDTO>();
            CreateMap<HomeDescriptionDTO, HomeDescription>();

            /***** Mappage pour AddAtelier *****/
            CreateMap<Atelier, AddAtelierDTO>();
            CreateMap<AddAtelierDTO, Atelier>();

            /***** Mappage pour Ecole *****/
            CreateMap<Ecole, EcoleDTO>();
            CreateMap<EcoleDTO, Ecole>();

            /***** Mappage pour Image *****/
            CreateMap<Image, ImageDTO>();
            CreateMap<ImageDTO, Image>();

            /***** Mappage pour Image Evenement *****/
            CreateMap<ImageEvenement, ImageEvenementDTO>();
            CreateMap<ImageEvenementDTO, ImageEvenement>();

            /***** Mappage pour Evenement *****/
            CreateMap<Evenement, EvenementDTO>();
            CreateMap<EvenementDTO, Evenement>();

            /***** Mappage pour Evenement *****/
            CreateMap<Evenement, AddEvenementDTO>();
            CreateMap<AddEvenementDTO, Evenement>();

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
