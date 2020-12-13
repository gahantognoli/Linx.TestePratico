using Linx.WebApp.MVC.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public class MusicaService : Service, IMusicaService
    {
        private readonly HttpClient _httpClient;

        public MusicaService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration.GetValue<string>("UrlPlayerAPI"));

            _httpClient = httpClient;
        }

        public async Task<MusicaViewModel> Adicionar(MusicaViewModel musicaViewModel)
        {
            var musicaContent = ObterConteudo(musicaViewModel);

            var response = await _httpClient.PostAsync("musicas", musicaContent);

            if (!TratarErrosResponse(response))
            {
                return new MusicaViewModel
                {
                    ResponseResult = await DeserializarResponse<ResponseResult>(response)
                };
            }

            return await DeserializarResponse<MusicaViewModel>(response); 
        }

        public async Task<MusicaViewModel> Atualizar(Guid id, MusicaViewModel musicaViewModel)
        {
            var musica = new MusicaViewModel();
            var musicaContent = ObterConteudo(musicaViewModel);

            var response = await _httpClient.PutAsync($"musicas/{id}", musicaContent);

            if (!TratarErrosResponse(response))
            {
                musica.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return musica;
        }

        public async Task<MusicaViewModel> Remover(Guid id)
        {
            var musica = new MusicaViewModel();
            var response = await _httpClient.DeleteAsync($"musicas/{id}");

            if (!TratarErrosResponse(response))
            {
                musica.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return musica;
        }

        public async Task<MusicaViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"musicas/{id}");

            TratarErrosResponse(response);

            return await DeserializarResponse<MusicaViewModel>(response);
        }

        public async Task<IEnumerable<MusicaViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("musicas");

            TratarErrosResponse(response);

            return await DeserializarResponse<IEnumerable<MusicaViewModel>>(response);
        }

        public async Task<IEnumerable<MusicaViewModel>> ObterPorArtista(string artista)
        {
            var response = await _httpClient.GetAsync($"musicas/por-artista?artista={artista}");

            TratarErrosResponse(response);

            return await DeserializarResponse<IEnumerable<MusicaViewModel>>(response);
        }

        public async Task<IEnumerable<MusicaViewModel>> ObterPorGenero(string genero)
        {
            var response = await _httpClient.GetAsync($"musicas/por-genero?genero={genero}");

            TratarErrosResponse(response);

            return await DeserializarResponse<IEnumerable<MusicaViewModel>>(response);
        }

        
    }
}
