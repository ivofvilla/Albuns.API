
using Albuns.Aplicacao.Commando.AdicionarAlbum;
using Albuns.Aplicacao.Commando.ApagarAlbum;
using Albuns.Aplicacao.Commando.AtualizarAlbum;
using Albuns.Aplicacao.Query.ObterAlbumPorId;
using Albuns.Aplicacao.Query.ObterAlbuns;
using Albuns.Domain.Entidades;
using Albuns.Domain.Repositorio;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Albuns.Infraestrutura
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IValidator<AdicionarAlbumCommand>, AdicionarAlbumValidator>();
            services.AddScoped<IValidator<ApagarAlbumCommand>, ApagarAlbumCommandValidator>();
            services.AddScoped<IValidator<AtualizarAlbumCommand>, AtualizarAlbumCommandValidator>();
            services.AddScoped<IValidator<ObterAlbumPorIdQuery>, ObterAlbumPorIdQueryValidator>();

            services.AddScoped<IRequestHandler<AdicionarAlbumCommand, bool>, AdicionarAlbumHandler>().Reverse();
            services.AddScoped<IRequestHandler<ApagarAlbumCommand, bool>, ApagarAlbumCommandHandler>().Reverse();
            services.AddScoped<IRequestHandler<AtualizarAlbumCommand, bool>, AtualizarAlbumCommandHandler>().Reverse();
            services.AddScoped<IRequestHandler<ObterAlbumPorIdQuery, Album>, ObterAlbumPorIdQueryHandler>().Reverse();
            services.AddScoped<IRequestHandler<ObterAlbunsQuery, IEnumerable<Album>>, ObterAlbunsQueryHandler>().Reverse();

        }
    }
}