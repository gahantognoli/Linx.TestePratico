using Linx.WebApp.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public interface IGeneroService
    {
        Task<GeneroViewModel> Adicionar(GeneroViewModel generoViewModel);
        Task<GeneroViewModel> Atualizar(Guid id, GeneroViewModel generoViewModel);
        Task<GeneroViewModel> Remover(Guid id);
        Task<GeneroViewModel> ObterPorId(Guid id);
        Task<IEnumerable<GeneroViewModel>> ObterTodos();
    }
}
