using Linx.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linx.Player.Domain.Entities
{
    public class Artista : Entity
    {
        public string Nome { get; private set; }
        public DateTime InicioCarreira { get; private set; }
        
        public virtual ICollection<Album> Albuns { get; set; }

        public Artista(string nome, DateTime inicioCarreira)
        {
            Nome = nome;
            InicioCarreira = inicioCarreira;

            Validar();
        }

        //E.F
        protected Artista() { }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome não pode estar vazio.");
        }
    }
}
