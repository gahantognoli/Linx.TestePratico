﻿using System;

namespace Linx.Player.API.ViewModels
{
    public class MusicaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int Idioma { get; set; }
        public Guid AlbumId { get; set; }
        public Guid GeneroId { get; set; }

        public virtual AlbumViewModel Album { get; set; }
        public virtual GeneroViewModel Genero { get; set; }
    }
}
