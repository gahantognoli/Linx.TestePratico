using Linx.WebApp.MVC.Extensions;
using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.Services.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Linx.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IMusicaService, MusicaService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            
            services.AddHttpClient<IAlbumService, AlbumService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IArtistaService, ArtistaService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IGeneroService, GeneroService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
