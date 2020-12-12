using AutoMapper;
using Linx.Player.API.ViewModels;
using Linx.Player.Domain.Entities;

namespace Linx.Player.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Musica, MusicaViewModel>();
            CreateMap<Album, AlbumViewModel>();
            CreateMap<Genero, GeneroViewModel>();
            CreateMap<Artista, ArtistaViewModel>();

        }
    }
}
