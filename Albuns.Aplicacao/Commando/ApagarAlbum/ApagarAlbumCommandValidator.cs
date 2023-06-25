using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.ApagarAlbum
{
    public class ApagarAlbumCommandValidator : AbstractValidator<ApagarAlbumCommand>
    {
        public ApagarAlbumCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("O ID do álbum é obrigatório.");
        }
    }
}
