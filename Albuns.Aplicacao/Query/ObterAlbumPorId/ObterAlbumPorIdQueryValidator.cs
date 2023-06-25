using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Query.ObterAlbumPorId
{
    public class ObterAlbumPorIdQueryValidator : AbstractValidator<ObterAlbumPorIdQuery>
    {
        public ObterAlbumPorIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("O ID do álbum é obrigatório.");
        }
    }
}
