using Albuns.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Query.ObterAlbuns
{
    public class ObterAlbunsQuery : IRequest<IEnumerable<Album>>
    {
    }
}
