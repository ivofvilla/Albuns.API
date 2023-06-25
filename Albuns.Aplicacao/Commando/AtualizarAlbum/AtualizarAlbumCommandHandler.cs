using Albuns.Aplicacao.Commando.ApagarAlbum;
using Albuns.Domain.Repositorio;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.AtualizarAlbum
{
    public class AtualizarAlbumCommandHandler : IRequestHandler<AtualizarAlbumCommand, bool>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IValidator<AtualizarAlbumCommand> _validator;

        public AtualizarAlbumCommandHandler(IAlbumRepository albumRepository, IValidator<AtualizarAlbumCommand> validator)
        {
            _albumRepository = albumRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(AtualizarAlbumCommand command, CancellationToken cancellationToken = default)
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

            album.Titulo = command.Titulo;
            album.Artista = command.Banda;
            album.QuantidadeFaixas = command.QuantidadeFaixas;
            album.Duplo = command.Duplo;
            album.CaminhoImagem = command.CaminhoImagem;

            await _albumRepository.AtualizarAsync(album, cancellationToken);

            return true;
        }
    }
}
