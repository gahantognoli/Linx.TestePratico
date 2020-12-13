using Linx.WebApp.MVC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Linx.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<IMusicaService, MusicaService>();
            services.AddHttpClient<IAlbumService, AlbumService>();
            services.AddHttpClient<IArtistaService, ArtistaService>();
            services.AddHttpClient<IGeneroService, GeneroService>();

            return services;
        }
    }
}
