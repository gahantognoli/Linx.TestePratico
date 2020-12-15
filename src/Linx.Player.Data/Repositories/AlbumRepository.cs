using Linx.Core.Data;
using Linx.Player.Data.Context;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linx.Player.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly PlayerContext _context;

        public AlbumRepository(PlayerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Adicionar(Album entity) => await _context.Albuns.AddAsync(entity);

        public void Atualizar(Album entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Albuns.Find(Id).Excluido = true;

        public async Task<Album> ObterPorId(Guid id) => await _context.Albuns
            .Include(p => p.Musicas).Include(p => p.Artista).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && !p.Excluido);

        public async Task<IEnumerable<Album>> ObterTodos() => await _context.Albuns
            .Include(p => p.Artista).AsNoTracking()
            .Where(p => !p.Excluido).ToListAsync();

        public void Dispose() => _context.Dispose();
    }
}
