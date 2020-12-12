using Linx.Player.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public interface IArtistaService : IDisposable
    {
        Task Adicionar(Artista artista);
        Task Atualizar(Artista artista);
        Task Remover(Guid id);
    }
}
