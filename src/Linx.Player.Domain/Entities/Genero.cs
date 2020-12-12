using Linx.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Linx.Player.Domain.Entities
{
    public class Genero : Entity
    {
        public string Nome { get; private set; }

        public virtual ICollection<Musica> Musicas { get; set; }

        public Genero(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        //E.F
        protected Genero() { }
    }
}
