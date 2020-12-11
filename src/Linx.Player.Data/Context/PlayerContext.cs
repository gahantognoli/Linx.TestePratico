using Linx.Core.Data;
using Linx.Player.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Linx.Player.Data.Context
{
    public class PlayerContext : DbContext, IUnitOfWork
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }

        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Artista> Artistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}
