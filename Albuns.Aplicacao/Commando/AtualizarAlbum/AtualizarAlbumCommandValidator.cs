using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.AtualizarAlbum
{
    public class AtualizarAlbumCommandValidator : AbstractValidator<AtualizarAlbumCommand>
    {
        public AtualizarAlbumCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("O ID do álbum é obrigatório.");

            RuleFor(command => command.Titulo)
                .NotEmpty().WithMessage("O título do álbum é obrigatório.");

            RuleFor(command => command.Banda)
                .NotEmpty().WithMessage("A banda do álbum é obrigatória.");

            RuleFor(command => command.QuantidadeFaixas)
                .GreaterThan(0).WithMessage("A quantidade de faixas do álbum deve ser maior que zero.");
        }
    }
}
