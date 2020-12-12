using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Linx.Player.API.ViewModels
{
    public class ArtistaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo {0} é {1}")]
        public string Nome { get; set; }
        public DateTime InicioCarreira { get; set; }

        public virtual ICollection<AlbumViewModel> Albuns { get; set; }
    }
}
