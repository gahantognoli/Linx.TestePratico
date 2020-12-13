using Linx.WebApp.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public interface IArtistaService
    {
        Task<ArtistaViewModel> Adicionar(ArtistaViewModel artistaViewModel);
        Task<ArtistaViewModel> Atualizar(Guid id, ArtistaViewModel artistaViewModel);
        Task<ArtistaViewModel> Remover(Guid id);
        Task<ArtistaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ArtistaViewModel>> ObterTodos();
    }
}
