using Linx.Player.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linx.Player.Data.Mappings
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Titulo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(p => p.Idioma)
                .IsRequired();

            builder
                .Property(p => p.Excluido)
                .IsRequired();

            builder
                .HasOne(p => p.Album)
                .WithMany(p => p.Musicas)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
               .HasOne(p => p.Genero)
               .WithMany(p => p.Musicas)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Musicas");
        }
    }
}
