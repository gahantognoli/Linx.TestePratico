using Linx.Player.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public interface IMusicaService : IDisposable
    {
        Task Adicionar(Musica musica);
        Task Atualizar(Musica musica);
        Task Remover(Guid id);
    }
}
