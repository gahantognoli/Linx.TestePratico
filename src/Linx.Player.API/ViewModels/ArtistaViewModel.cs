﻿using System;
using System.Collections.Generic;

namespace Linx.Player.API.ViewModels
{
    public class ArtistaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime InicioCarreira { get; set; }

        public virtual ICollection<AlbumViewModel> Albuns { get; set; }
    }
}
