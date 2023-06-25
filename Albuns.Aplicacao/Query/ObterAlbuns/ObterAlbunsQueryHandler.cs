using Albuns.Domain.Entidades;
using Albuns.Domain.Repositorio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Query.ObterAlbuns
{
    public class ObterAlbunsQueryHandler : IRequestHandler<ObterAlbunsQuery, IEnumerable<Album>>
    {
        private readonly IAlbumRepository _albumRepository;

        public ObterAlbunsQueryHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<Album>> Handle(ObterAlbunsQuery request, CancellationToken cancellationToken)
        {
            return await _albumRepository.ObterTodosAsync(cancellationToken);
        }
    }
}
