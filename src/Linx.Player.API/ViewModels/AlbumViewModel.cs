﻿using System;
using System.Collections.Generic;

namespace Linx.Player.API.ViewModels
{
    public class AlbumViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ArtistaId { get; set; }

        public ArtistaViewModel Artista { get; set; }
        public virtual ICollection<MusicaViewModel> Musicas { get; set; }
    }
}
