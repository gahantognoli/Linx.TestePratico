using Linx.WebApp.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public interface IMusicaService
    {
        Task<MusicaViewModel> Adicionar(MusicaViewModel musicaViewModel);
        Task<MusicaViewModel> Atualizar(Guid id, MusicaViewModel musicaViewModel);
        Task<MusicaViewModel> Remover(Guid id);
        Task<MusicaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<MusicaViewModel>> ObterTodos();
        Task<IEnumerable<MusicaViewModel>> ObterPorArtista(string artista);
        Task<IEnumerable<MusicaViewModel>> ObterPorGenero(string genero);

    }
}
