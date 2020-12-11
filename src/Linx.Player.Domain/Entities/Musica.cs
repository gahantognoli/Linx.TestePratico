using Linx.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Linx.Player.Domain.Entities
{
    public class Musica : Entity
    {
        public string Titulo { get; private set; }
        public string Idioma { get; private set; }
        public Guid AlbumId { get; private set; }
        public Guid GeneroId { get; private set; }

        public virtual Album Album { get; set; }
        public virtual Genero Genero { get; set; }


        public Musica(string titulo, string idioma, Guid albumId, Guid generoId)
        {
            Titulo = titulo;
            Idioma = idioma;
            AlbumId = albumId;
            GeneroId = generoId;

            Validar();
        }

        //E.F
        protected Musica() { }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Titulo, "O campo titulo não pode estar vazio.");
            Validacoes.ValidarSeIgual(AlbumId, Guid.Empty, "É necessário informar o album da música.");
            Validacoes.ValidarSeIgual(GeneroId, Guid.Empty, "É necessário informar o genero da música.");
        }
    }
}
