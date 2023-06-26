using Albuns.Domain.Entidades;
using Albuns.Domain.Repositorio;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albuns.Aplicacao.Commando.AdicionarAlbum
{
    public class AdicionarAlbumHandler : IRequestHandler<AdicionarAlbumCommand, bool>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IValidator<AdicionarAlbumCommand> _validator;

        public AdicionarAlbumHandler(IAlbumRepository albumRepository, IValidator<AdicionarAlbumCommand> validator)
        {
            _albumRepository = albumRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(AdicionarAlbumCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var album = new Album
            {
                Titulo = command.Titulo,
                Artista = command.Artista,
                QuantidadeFaixas = command.QuantidadeFaixas,
                Duplo = command.Duplo,
                //CaminhoImagem = command.CaminhoImagem,
            };

            await _albumRepository.AdicionarAsync(album, cancellationToken);

            return true;
        }
    }
}
