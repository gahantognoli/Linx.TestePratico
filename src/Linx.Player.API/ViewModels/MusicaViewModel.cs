﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Linx.Player.API.ViewModels
{
    public class MusicaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do campo {0} é {1}")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Idioma { get; set; }
        public Guid AlbumId { get; set; }
        public Guid GeneroId { get; set; }

        public virtual AlbumViewModel Album { get; set; }
        public virtual GeneroViewModel Genero { get; set; }
    }
}