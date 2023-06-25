using Albuns.Domain.Repositorio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.ApagarAlbum
{
    public class ApagarAlbumCommandHandler
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IValidator<ApagarAlbumCommand> _validator;

        public ApagarAlbumCommandHandler(IAlbumRepository albumRepository, IValidator<ApagarAlbumCommand> validator)
        {
            _albumRepository = albumRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(ApagarAlbumCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                // Lidar com os erros de validação, se necessário
                return false;
            }

            var album = await _albumRepository.ObterPorIdAsync(command.Id, cancellationToken);
            if (album == null)
            {
                // Lidar com o álbum não encontrado, se necessário
                return false;
            }

            await _albumRepository.RemoverAsync(album, cancellationToken);

            return true;
        }
    }
}
