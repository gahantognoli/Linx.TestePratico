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
    public class MusicaRepository : IMusicaRepository
    {
        private readonly PlayerContext _context;
        
        public MusicaRepository(PlayerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Adicionar(Musica entity) => await _context.Musicas.AddAsync(entity);

        public void Atualizar(Musica entity) => _context.Update(entity);

        public void Remover(Guid Id) => _context.Musicas.Find(Id).Excluido = true;

        public async Task<Musica> ObterPorId(Guid id) => await _context.Musicas
            .Include(p => p.Genero).Include(p => p.Album).ThenInclude(p => p.Artista)
            .AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && !p.Excluido);

        public async Task<IEnumerable<Musica>> ObterTodos() => await _context.Musicas.AsNoTracking()
            .Include(p => p.Album).Include(p => p.Genero)
            .Where(p => !p.Excluido).ToListAsync();

        public async Task<IEnumerable<Musica>> ObterPorGenero(string genero)
        {
            IEnumerable<Musica> musicas;

            using(var connection = _context.Database.GetDbConnection())
            {
                musicas = await connection.QueryAsync<Musica, Genero, Album, Artista, Musica>(
                    "usp_Musicas_ObterPorGenero",
                    (musica, genero, album, artista) =>
                    {
                        musica.Genero = genero;
                        musica.Album = album;
                        musica.Album.Artista = artista;
                        return musica;
                    },
                    new { genero },
                    commandType: CommandType.StoredProcedure);
            }

            return musicas;
        }

        public async Task<IEnumerable<Musica>> ObterPorArtista(string artista)
        {
            IEnumerable<Musica> musicas;

            using (var connection = _context.Database.GetDbConnection())
            {
                musicas = await connection.QueryAsync<Musica, Genero, Album, Artista, Musica>(
                    "usp_Musicas_ObterPorArtista",
                    (musica, genero, album, artista) =>
                    {
                        musica.Genero = genero;
                        musica.Album = album;
                        musica.Album.Artista = artista;
                        return musica;
                    },
                    new { artista },
                    commandType: CommandType.StoredProcedure);
            }

            return musicas;
        }

        public void Dispose() => _context.Dispose();
    }
}
