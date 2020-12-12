using Linx.Core.DomainObjects;
using System;

namespace Linx.Player.Domain.Entities
{
    public class Musica : Entity
    {
        public string Titulo { get; private set; }
        public int Idioma { get; private set; }
        public Guid AlbumId { get; private set; }
        public Guid GeneroId { get; private set; }

        public virtual Album Album { get; set; }
        public virtual Genero Genero { get; set; }


        public Musica(Guid id, string titulo, int idioma, Guid albumId, Guid generoId)
        {
            Id = id;
            Titulo = titulo;
            Idioma = idioma;
            AlbumId = albumId;
            GeneroId = generoId;
        }

        //E.F
        protected Musica() { }
    }
}
