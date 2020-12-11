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
    public class GeneroRepository : IGeneroRepository
    {
        private readonly PlayerContext _context;

        public GeneroRepository(PlayerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async void Adicionar(Genero entity) => await _context.Generos.AddAsync(entity);

        public void Atualizar(Genero entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Remove(_context.Generos.Find(Id));

        public async Task<Genero> ObterPorId(Guid id) => await _context.Generos.FindAsync(id);

        public async Task<IEnumerable<Genero>> ObterTodos() => await _context.Generos.ToListAsync();

        public void Dispose() => _context.Dispose();
    }
}
