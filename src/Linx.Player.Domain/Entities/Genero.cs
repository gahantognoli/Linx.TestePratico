using Linx.Core.DomainObjects;
using System.Collections.Generic;

namespace Linx.Player.Domain.Entities
{
    public class Genero : Entity
    {
        public string Nome { get; private set; }

        public virtual ICollection<Musica> Musicas { get; set; }

        public Genero(string nome)
        {
            Nome = nome;

            Validar();
        }

        //E.F
        protected Genero() { }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
        }
    }
}
