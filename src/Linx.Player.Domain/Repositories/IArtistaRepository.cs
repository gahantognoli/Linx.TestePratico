using Linx.Core.Data;
using Linx.Player.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Repositories
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        Task<IEnumerable<Artista>> ObterArtistasComMaisMusicas();
    }
}
