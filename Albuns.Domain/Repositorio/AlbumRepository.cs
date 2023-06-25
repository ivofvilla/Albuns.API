﻿using Albuns.Domain.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            string query = "SELECT * FROM Albums WHERE Id = @Id";
            var parameters = new { Id = id };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                return await _connection.QuerySingleOrDefaultAsync<Album>(commandDefinition);
            }
        }

        public async Task<IEnumerable<Album>> ObterTodosAsync(CancellationToken cancellationToken = default)
        {
            string query = "SELECT * FROM Albums";

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, cancellationToken: cancellationTokenSource.Token);
                return await _connection.QueryAsync<Album>(commandDefinition);
            }
        }

        public async Task AdicionarAsync(Album album, CancellationToken cancellationToken = default)
        {
            string query = "INSERT INTO Albums (Id, Titulo, Banda, QuantidadeFaixas, Duplo) " +
                           "VALUES (@Id, @Titulo, @Banda, @QuantidadeFaixas, @Duplo)";
            var parameters = new
            {
                Id = album.Id,
                Titulo = album.Titulo,
                Banda = album.Banda,
                QuantidadeFaixas = album.QuantidadeFaixas,
                Duplo = album.Duplo
            };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                await _connection.ExecuteAsync(commandDefinition);
            }
        }

        public async Task AtualizarAsync(Album album, CancellationToken cancellationToken = default)
        {
            string query = "UPDATE Albums SET Titulo = @Titulo, Banda = @Banda, QuantidadeFaixas = @QuantidadeFaixas, Duplo = @Duplo " +
                           "WHERE Id = @Id";
            var parameters = new
            {
                Id = album.Id,
                Titulo = album.Titulo,
                Banda = album.Banda,
                QuantidadeFaixas = album.QuantidadeFaixas,
                Duplo = album.Duplo
            };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                await _connection.ExecuteAsync(commandDefinition);
            }
        }

        public async Task RemoverAsync(Album album, CancellationToken cancellationToken = default)
        {
            string query = "DELETE FROM Albums WHERE Id = @Id";
            var parameters = new { Id = album.Id };

            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var commandDefinition = new CommandDefinition(query, parameters, cancellationToken: cancellationTokenSource.Token);
                await _connection.ExecuteAsync(commandDefinition);
            }
        }
    }
}
