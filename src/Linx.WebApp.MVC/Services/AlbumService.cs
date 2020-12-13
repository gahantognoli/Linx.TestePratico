using Linx.WebApp.MVC.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public class AlbumService : Service, IAlbumService
    {
        private readonly HttpClient _httpClient;

        public AlbumService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration.GetValue<string>("UrlPlayerAPI"));

            _httpClient = httpClient;
        }

        public async Task<AlbumViewModel> Adicionar(AlbumViewModel albumViewModel)
        {
            var albumContent = ObterConteudo(albumViewModel);

            var response = await _httpClient.PostAsync("albuns", albumContent);

            if (!TratarErrosResponse(response))
            {
                return new AlbumViewModel
                {
                    ResponseResult = await DeserializarResponse<ResponseResult>(response)
                };
            }

            return await DeserializarResponse<AlbumViewModel>(response);
        }

        public async Task<AlbumViewModel> Atualizar(Guid id, AlbumViewModel albumViewModel)
        {
            var album = new AlbumViewModel();
            var albumContent = ObterConteudo(albumViewModel);

            var response = await _httpClient.PutAsync($"albuns/{id}", albumContent);

            if (!TratarErrosResponse(response))
            {
                album.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return album;
        }

        public async Task<AlbumViewModel> Remover(Guid id)
        {
            var album = new AlbumViewModel();
            var response = await _httpClient.DeleteAsync($"albuns/{id}");

            if (!TratarErrosResponse(response))
            {
                album.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return album;
        }

        public async Task<AlbumViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"albuns/{id}");

            TratarErrosResponse(response);

            return await DeserializarResponse<AlbumViewModel>(response);
        }

        public async Task<IEnumerable<AlbumViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("albuns");

            TratarErrosResponse(response);

            return await DeserializarResponse<IEnumerable<AlbumViewModel>>(response);
        }
    }
}
