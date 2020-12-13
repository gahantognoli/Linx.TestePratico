using Linx.WebApp.MVC.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public class ArtistaService : Service, IArtistaService
    {
        private readonly HttpClient _httpClient;

        public ArtistaService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration.GetValue<string>("UrlPlayerAPI"));

            _httpClient = httpClient;
        }

        public async Task<ArtistaViewModel> Adicionar(ArtistaViewModel artistaViewModel)
        {
            var artistaContent = ObterConteudo(artistaViewModel);

            var response = await _httpClient.PostAsync("artistas", artistaContent);

            if (!TratarErrosResponse(response))
            {
                return new ArtistaViewModel
                {
                    ResponseResult = await DeserializarResponse<ResponseResult>(response)
                };
            }

            return await DeserializarResponse<ArtistaViewModel>(response);
        }

        public async Task<ArtistaViewModel> Atualizar(Guid id, ArtistaViewModel artistaViewModel)
        {
            var artista = new ArtistaViewModel();
            var artistaContent = ObterConteudo(artistaViewModel);

            var response = await _httpClient.PutAsync($"artistas/{id}", artistaContent);

            if (!TratarErrosResponse(response))
            {
                artista.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return artista;
        }

        public async Task<ArtistaViewModel> Remover(Guid id)
        {
            var artista = new ArtistaViewModel();
            var response = await _httpClient.DeleteAsync($"artistas/{id}");

            if (!TratarErrosResponse(response))
            {
                artista.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return artista;
        }

        public async Task<ArtistaViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"artistas/{id}");

            TratarErrosResponse(response);

            return await DeserializarResponse<ArtistaViewModel>(response);
        }

        public async Task<IEnumerable<ArtistaViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("artistas");

            TratarErrosResponse(response);

            return await DeserializarResponse<IEnumerable<ArtistaViewModel>>(response);
        }

        
    }
}
