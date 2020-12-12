using Linx.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Linx.Player.Domain.Entities
{
    public class Album : Entity
    {
        public string Nome { get; private set; }
        public Guid ArtistaId { get; private set; }
        
        public Artista Artista { get; set; }
        public virtual ICollection<Musica> Musicas { get; set; }

        public Album(Guid id, string nome, Guid artistaId)
        {
            Id = id;
            Nome = nome;
            ArtistaId = artistaId;
        }

        //E.F
        protected Album() { }
    }
}
