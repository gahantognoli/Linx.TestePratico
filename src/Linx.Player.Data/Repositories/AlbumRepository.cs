using Linx.Core.Data;
using Linx.Player.Data.Context;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async void Adicionar(Album entity) => await _context.Albuns.AddAsync(entity);

        public void Atualizar(Album entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Remove(_context.Albuns.Find(Id));

        public async Task<Album> ObterPorId(Guid id) => await _context.Albuns.FindAsync(id);

        public async Task<IEnumerable<Album>> ObterTodos() => await _context.Albuns.ToListAsync();

        public void Dispose() => _context.Dispose();
    }
}
