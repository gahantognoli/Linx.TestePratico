using System;
using System.Collections.Generic;

namespace Linx.Player.API.ViewModels
{
    public class GeneroViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<MusicaViewModel> Musicas { get; set; }
    }
}
