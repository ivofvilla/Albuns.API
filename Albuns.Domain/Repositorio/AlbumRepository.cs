using Albuns.Domain.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Albuns.Domain.Repositorio
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IDbConnection _connection;

        public AlbumRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Album> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            string query = "SELECT * FROM Albuns WHERE Id = @Id";
            var parameters = new { Id = id };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                return await _connection.QuerySingleOrDefaultAsync<Album>(commandDefinition);
            }
        }

        public async Task<IEnumerable<Album>> ObterTodosAsync(CancellationToken cancellationToken = default)
        {
            string query = "SELECT * FROM Albuns";

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, cancellationToken: cancellationTokenSource.Token);
                return await _connection.QueryAsync<Album>(commandDefinition);
            }
        }

        public async Task AdicionarAsync(Album album, CancellationToken cancellationToken = default)
        {
            string query = "INSERT INTO Albuns (Id, Titulo, Artista, QuantidadeFaixas, Duplo, CaminhoImagem, CriadoEm, AtualizadoEm) " +
                           "VALUES (@Id, @Titulo, @Artista, @QuantidadeFaixas, @Duplo, @CaminhoImagem, @CriadoEm, @CriadoEm)";

            var data = DateTime.Now;

            var parameters = new
            {
                Id = album.Id,
                Titulo = album.Titulo,
                Artista = album.Artista,
                QuantidadeFaixas = album.QuantidadeFaixas,
                Duplo = album.Duplo,
                CaminhoImagem = album.CaminhoImagem,
                CriadoEm = data,
                AtualizadoEm = data

            };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                await _connection.ExecuteAsync(commandDefinition);
            }
        }

        public async Task AtualizarAsync(Album album, CancellationToken cancellationToken = default)
        {
            string query = "UPDATE Albuns SET Titulo = @Titulo, Artista = @Artista, QuantidadeFaixas = @QuantidadeFaixas, Duplo = @Duplo, CaminhoImagem =@CaminhoImagem, AtualizadoEm = @AtualizadoEm  " +
                           "WHERE Id = @Id";

            var data = DateTime.Now;

            var parameters = new
            {
                Id = album.Id,
                Titulo = album.Titulo,
                Banda = album.Artista,
                QuantidadeFaixas = album.QuantidadeFaixas,
                Duplo = album.Duplo,
                CaminhoImagem = album.CaminhoImagem,
                AtualizadoEm = data
            };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                await _connection.ExecuteAsync(commandDefinition);
            }
        }

        public async Task RemoverAsync(Album album, CancellationToken cancellationToken = default)
        {
            string query = "DELETE FROM Albuns WHERE Id = @Id";
            var parameters = new { Id = album.Id };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                await _connection.ExecuteAsync(commandDefinition);
            }
        }
    }
}
