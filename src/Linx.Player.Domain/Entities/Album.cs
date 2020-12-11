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

        public Album(string nome, Guid artistaId)
        {
            Nome = nome;
            ArtistaId = artistaId;
        }

        //E.F
        protected Album() { }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
            Validacoes.ValidarSeIgual(ArtistaId, Guid.Empty, "É necessário informar o artista do album.");
        }
    }
}
