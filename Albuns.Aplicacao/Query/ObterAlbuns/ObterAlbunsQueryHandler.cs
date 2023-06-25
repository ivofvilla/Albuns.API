using Albuns.Domain.Entidades;
using Albuns.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Query.ObterAlbuns
{
    public class ObterAlbunsQueryHandler
    {
        private readonly IAlbumRepository _albumRepository;

        public ObterAlbunsQueryHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<Album>> Handle(CancellationToken cancellationToken = default)
        {
            var albuns = await _albumRepository.ObterTodosAsync(cancellationToken);

            return albuns;
        }
    }
}
