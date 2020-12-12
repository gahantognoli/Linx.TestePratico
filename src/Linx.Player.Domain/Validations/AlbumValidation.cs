using FluentValidation;
using Linx.Player.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linx.Player.Domain.Validations
{
    public class AlbumValidation : AbstractValidator<Album>
    {
        public AlbumValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O campo nome não pode estar vazio.");

            RuleFor(p => p.ArtistaId)
                .NotEqual(Guid.Empty)
                .WithMessage("É necessário informar o artista do album.");
        }
    }
}
