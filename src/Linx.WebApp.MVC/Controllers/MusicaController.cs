using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Controllers
{
    public class MusicaController : MainController
    {
        private readonly IMusicaService _musicaService;

        public MusicaController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task<IActionResult> Index(string pesquisarPor = null, string valor = null)
        {
            return View(await Pesquisar(pesquisarPor, valor));
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            return View(await _musicaService.ObterPorId(id));
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(MusicaViewModel musicaViewModel)
        {
            if (!ModelState.IsValid) return View(musicaViewModel);

            var musicaResponse = await _musicaService.Adicionar(musicaViewModel);

            if (ResponsePossuiErros(musicaResponse.ResponseResult)) return View(musicaResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            return View(await _musicaService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, MusicaViewModel musicaViewModel)
        {
            if (!ModelState.IsValid) return View(musicaViewModel);

            var musicaResponse = await _musicaService.Atualizar(id, musicaViewModel);

            if (ResponsePossuiErros(musicaResponse.ResponseResult)) return View(musicaResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remover(Guid id)
        {
            return View(await _musicaService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmaRemover(Guid id)
        {
            var musicaResponse = await _musicaService.Remover(id);

            if (ResponsePossuiErros(musicaResponse.ResponseResult)) 
            {
                var musica = await _musicaService.ObterPorId(id);
                musica.ResponseResult = musicaResponse.ResponseResult;
                return View(musica);
            };

            return RedirectToAction("Index");
        }

        private async Task<IEnumerable<MusicaViewModel>> Pesquisar(string pesquisarPor, string valor)
        {
            if (!string.IsNullOrEmpty(pesquisarPor))
            {
                if (pesquisarPor == "artista") return await _musicaService.ObterPorArtista(valor);
                else if (pesquisarPor == "genero") return await _musicaService.ObterPorGenero(valor);
            }

            return await _musicaService.ObterTodos();
        }
    }
}
