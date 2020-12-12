using Dapper;
using Linx.Core.Data;
using Linx.Player.Data.Context;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Linx.Player.Data.Repositories
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly PlayerContext _context;

        public ArtistaRepository(PlayerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Adicionar(Artista entity) => await _context.Artistas.AddAsync(entity);

        public void Atualizar(Artista entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Artistas.Find(Id).Excluido = true;

        public async Task<Artista> ObterPorId(Guid id) => await _context.Artistas
            .Include(p => p.Albuns).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && !p.Excluido);

        public async Task<IEnumerable<Artista>> ObterTodos() => await _context.Artistas.AsNoTracking().Where(p => !p.Excluido).ToListAsync();

        public void Dispose() => _context.Dispose();

        public async Task<IEnumerable<Artista>> ObterArtistasComMaisMusicas()
        {
            IEnumerable<Artista> artistas;

            using (var connection = _context.Database.GetDbConnection())
            {
                artistas = await connection.QueryAsync<Artista>(
                    "usp_Artistas_ComMaisMusicas",
                    commandType: CommandType.StoredProcedure);
            }

            return artistas;
        }
    }
}
