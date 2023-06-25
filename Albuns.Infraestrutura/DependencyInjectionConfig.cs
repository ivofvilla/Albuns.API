
using Albuns.Aplicacao.Commando.AdicionarAlbum;
using Albuns.Aplicacao.Commando.ApagarAlbum;
using Albuns.Aplicacao.Commando.AtualizarAlbum;
using Albuns.Aplicacao.Query.ObterAlbumPorId;
using Albuns.Aplicacao.Query.ObterAlbuns;
using Albuns.Domain.Entidades;
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

            services.AddScoped<IRequestHandler<AdicionarAlbumCommand, bool>, AdicionarAlbumHandler>();
            services.AddScoped<IRequestHandler<ApagarAlbumCommand, bool>, ApagarAlbumCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarAlbumCommand, bool>, AtualizarAlbumCommandHandler>();
            services.AddScoped<IRequestHandler<ObterAlbumPorIdQuery, Album>, ObterAlbumPorIdQueryHandler>();
            services.AddScoped<IRequestHandler<ObterAlbunsQuery, IEnumerable<Album>>, ObterAlbunsQueryHandler>();
        }
    }
}