using Linx.WebApp.MVC.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public class GeneroService : Service, IGeneroService
    {
        private readonly HttpClient _httpClient;

        public GeneroService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration.GetValue<string>("UrlPlayerAPI"));

            _httpClient = httpClient;
        }

        public async Task<GeneroViewModel> Adicionar(GeneroViewModel generoViewModel)
        {
            var generoContent = ObterConteudo(generoViewModel);

            var response = await _httpClient.PostAsync("generos", generoContent);

            if (!TratarErrosResponse(response))
            {
                return new GeneroViewModel
                {
                    ResponseResult = await DeserializarResponse<ResponseResult>(response)
                };
            }

            return await DeserializarResponse<GeneroViewModel>(response);
        }

        public async Task<GeneroViewModel> Atualizar(Guid id, GeneroViewModel generoViewModel)
        {
            var genero = new GeneroViewModel();
            var generoContent = ObterConteudo(generoViewModel);

            var response = await _httpClient.PutAsync($"generos/{id}", generoContent);

            if (!TratarErrosResponse(response))
            {
                genero.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return genero;
        }

        public async Task<GeneroViewModel> Remover(Guid id)
        {
            var genero = new GeneroViewModel();
            var response = await _httpClient.DeleteAsync($"generos/{id}");

            if (!TratarErrosResponse(response))
            {
                genero.ResponseResult = await DeserializarResponse<ResponseResult>(response);
            }

            return genero;
        }

        public async Task<GeneroViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"generos/{id}");

            TratarErrosResponse(response);

            return await DeserializarResponse<GeneroViewModel>(response);
        }

        public async Task<IEnumerable<GeneroViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("generos");

            TratarErrosResponse(response);

            return await DeserializarResponse<IEnumerable<GeneroViewModel>>(response);
        }
    }
}
