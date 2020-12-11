using Linx.Player.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linx.Player.Data.Mappings
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .HasOne(p => p.Artista)
                .WithMany(p => p.Albuns)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Albuns");
        }
    }
}
