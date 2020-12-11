﻿// <auto-generated />
using System;
using Linx.Player.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Linx.Player.Data.Migrations
{
    [DbContext(typeof(PlayerContext))]
    [Migration("20201211021946_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Linx.Player.Domain.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("Linx.Player.Domain.Entities.Artista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InicioCarreira")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Linx.Player.Domain.Entities.Genero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Linx.Player.Domain.Entities.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GeneroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Musicas");
                });

            modelBuilder.Entity("Linx.Player.Domain.Entities.Album", b =>
                {
                    b.HasOne("Linx.Player.Domain.Entities.Artista", "Artista")
                        .WithMany("Albuns")
                        .HasForeignKey("ArtistaId")
                        .IsRequired();
                });

            modelBuilder.Entity("Linx.Player.Domain.Entities.Musica", b =>
                {
                    b.HasOne("Linx.Player.Domain.Entities.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .IsRequired();

                    b.HasOne("Linx.Player.Domain.Entities.Genero", "Genero")
                        .WithMany("Musicas")
                        .HasForeignKey("GeneroId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}