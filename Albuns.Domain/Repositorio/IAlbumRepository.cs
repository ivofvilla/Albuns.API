using Albuns.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Domain.Repositorio
{
    public interface IAlbumRepository
    {
        Task<Album> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Album>> ObterTodosAsync(CancellationToken cancellationToken = default);
        Task AdicionarAsync(Album album, CancellationToken cancellationToken = default);
        Task AtualizarAsync(Album album, CancellationToken cancellationToken = default);
        Task RemoverAsync(Album album, CancellationToken cancellationToken = default);
    }
}
