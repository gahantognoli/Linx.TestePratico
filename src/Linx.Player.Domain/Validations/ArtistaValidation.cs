using FluentValidation;
using Linx.Player.Domain.Entities;

namespace Linx.Player.Domain.Validations
{
    public class ArtistaValidation : AbstractValidator<Artista>
    {
        public ArtistaValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O campo nome não pode estar vazio.");
        }
    }
}
