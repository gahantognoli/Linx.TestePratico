using Linx.Player.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public interface IAlbumService : IDisposable
    {
        Task Adicionar(Album album);
        Task Atualizar(Album album);
        Task Remover(Guid id);
    }
}
