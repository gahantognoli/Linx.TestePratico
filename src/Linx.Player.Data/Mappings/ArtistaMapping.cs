using Linx.Player.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linx.Player.Data.Mappings
{
    public class ArtistaMapping : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(p => p.Excluido)
                .IsRequired();

            builder.ToTable("Artistas");
        }
    }
}
