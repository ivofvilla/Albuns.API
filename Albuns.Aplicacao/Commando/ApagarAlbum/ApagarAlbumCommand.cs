using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.ApagarAlbum
{
    public class ApagarAlbumCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
