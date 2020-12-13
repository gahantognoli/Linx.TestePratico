using Linx.WebApp.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public interface IAlbumService
    {
        Task<AlbumViewModel> Adicionar(AlbumViewModel albumViewModel);
        Task<AlbumViewModel> Atualizar(Guid id, AlbumViewModel albumViewModel);
        Task<AlbumViewModel> Remover(Guid id);
        Task<AlbumViewModel> ObterPorId(Guid id);
        Task<IEnumerable<AlbumViewModel>> ObterTodos();
    }
}
