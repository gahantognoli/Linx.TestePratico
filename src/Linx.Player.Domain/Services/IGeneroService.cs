using Linx.Player.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public interface IGeneroService : IDisposable
    {
        Task Adicionar(Genero genero);
        Task Atualizar(Genero genero);
        Task Remover(Guid id);
    }
}
