using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Linx.WebApp.MVC.ViewModels
{
    public class GeneroViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo {0} é {1}")]
        public string Nome { get; set; }

        public virtual ICollection<MusicaViewModel> Musicas { get; set; }

        public ResponseResult ResponseResult { get; set; }
    }
}
