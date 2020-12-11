using Linx.Core.Data;
using Linx.Core.DomainObjects;
using Linx.Player.Data.Context;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Player.Data.Repositories
{
    public class MusicaRepository : IMusicaRepository
    {
        private readonly PlayerContext _context;
        
        public MusicaRepository(PlayerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async void Adicionar(Musica entity) => await _context.Musicas.AddAsync(entity);

        public void Atualizar(Musica entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Remove(_context.Musicas.Find(Id));

        public async Task<Musica> ObterPorId(Guid id) => await _context.Musicas.FindAsync(id);

        public async Task<IEnumerable<Musica>> ObterTodos() => await _context.Musicas.ToListAsync();

        public void Dispose() => _context.Dispose();
    }
}
