using Linx.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Linx.Player.Domain.Entities
{
    public class Artista : Entity
    {
        public string Nome { get; private set; }
        public DateTime InicioCarreira { get; private set; }
        
        public virtual ICollection<Album> Albuns { get; set; }

        public Artista(Guid id, string nome, DateTime inicioCarreira)
        {
            Id = id;
            Nome = nome;
            InicioCarreira = inicioCarreira;
        }

        //E.F
        protected Artista() { }
    }
}
