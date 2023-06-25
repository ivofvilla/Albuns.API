using Albuns.Domain.Entidades;
using Albuns.Domain.Repositorio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Query.ObterAlbumPorId
{
    public class ObterAlbumPorIdQueryHandler
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IValidator<ObterAlbumPorIdQuery> _validator;

        public ObterAlbumPorIdQueryHandler(IAlbumRepository albumRepository, IValidator<ObterAlbumPorIdQuery> validator)
        {
            _albumRepository = albumRepository;
            _validator = validator;
        }

        public async Task<Album> Handle(ObterAlbumPorIdQuery query, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(query, cancellationToken);
            if (!validationResult.IsValid)
            {
                return null;
            }

            var album = await _albumRepository.ObterPorIdAsync(query.Id, cancellationToken);

            return album;
        }
    }
}
