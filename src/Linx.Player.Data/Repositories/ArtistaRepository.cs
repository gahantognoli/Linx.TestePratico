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
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly PlayerContext _context;

        public ArtistaRepository(PlayerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async void Adicionar(Artista entity) => await _context.Artistas.AddAsync(entity);

        public void Atualizar(Artista entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Remove(_context.Artistas.Find(Id));

        public async Task<Artista> ObterPorId(Guid id) => await _context.Artistas.FindAsync(id);

        public async Task<IEnumerable<Artista>> ObterTodos() => await _context.Artistas.ToListAsync();

        public void Dispose() => _context.Dispose();
    }
}
