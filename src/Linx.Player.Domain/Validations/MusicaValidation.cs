using FluentValidation;
using Linx.Player.Domain.Entities;
using System;

namespace Linx.Player.Domain.Validations
{
    public class MusicaValidation : AbstractValidator<Musica>
    {
        public MusicaValidation()
        {
            RuleFor(p => p.Titulo)
                .NotEmpty()
                .WithMessage("O campo titulo não pode estar vazio.");

            RuleFor(p => p.AlbumId)
                .NotEqual(Guid.Empty)
                .WithMessage("É necessário informar o album da música.");

            RuleFor(p => p.GeneroId)
                .NotEqual(Guid.Empty)
                .WithMessage("É necessário informar o genero da música.");
        }
    }
}
