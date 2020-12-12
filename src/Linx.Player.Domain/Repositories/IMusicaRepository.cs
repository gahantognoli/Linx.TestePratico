using Linx.Core.Data;
using Linx.Player.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Repositories
{
    public interface IMusicaRepository : IRepository<Musica>
    {
        Task<IEnumerable<Musica>> ObterPorGenero(string genero);
        Task<IEnumerable<Musica>> ObterPorArtista(string artista);
    }
}
