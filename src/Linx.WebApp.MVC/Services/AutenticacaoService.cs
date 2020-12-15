using Linx.WebApp.MVC.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(configuration.GetValue<string>("UrlAutenticacaoAPI"));
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarResponse<ResponseResult>(response)
                };
            };

            return await DeserializarResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarResponse<ResponseResult>(response)
                };
            };

            return await DeserializarResponse<UsuarioRespostaLogin>(response);
        }
    }
}
