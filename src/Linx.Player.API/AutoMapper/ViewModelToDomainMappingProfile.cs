using AutoMapper;
using Linx.Player.API.ViewModels;
using Linx.Player.Domain.Entities;

namespace Linx.Player.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<MusicaViewModel, Musica>()
                .ConstructUsing(p => new Musica(p.Id, p.Titulo, p.Idioma, p.AlbumId, p.GeneroId));

            CreateMap<AlbumViewModel, Album>()
                .ConstructUsing(p => new Album(p.Id, p.Nome, p.ArtistaId));

            CreateMap<GeneroViewModel, Genero>()
                .ConstructUsing(p => new Genero(p.Id, p.Nome));

            CreateMap<ArtistaViewModel, Artista>()
                .ConstructUsing(p => new Artista(p.Id, p.Nome, p.InicioCarreira));
        }
    }
}
