using FluentValidation;

namespace Albuns.Aplicacao.Commando.AdicionarAlbum
{
    public class AdicionarAlbumValidator : AbstractValidator<AdicionarAlbumCommand>
    {
        public AdicionarAlbumValidator()
        {
            RuleFor(command => command.Titulo)
                .NotEmpty().WithMessage("O título do álbum é obrigatório.");

            RuleFor(command => command.Banda)
                .NotEmpty().WithMessage("A banda do álbum é obrigatória.");

            RuleFor(command => command.QuantidadeFaixas)
                .GreaterThan(0).WithMessage("A quantidade de faixas do álbum deve ser maior que zero.");
        }
    }
}
