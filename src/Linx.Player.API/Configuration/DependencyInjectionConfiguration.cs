using Linx.Core.Notifications;
using Linx.Player.Data.Repositories;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Linx.Player.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();

            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistaService, ArtistaService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
