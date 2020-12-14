using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Controllers
{
    public class MusicaController : MainController
    {
        private readonly IMusicaService _musicaService;
        private readonly IAlbumService _albumService;
        private readonly IGeneroService _generoService;

        public MusicaController(IMusicaService musicaService,
            IAlbumService albumService,
            IGeneroService generoService)
        {
            _musicaService = musicaService;
            _albumService = albumService;
            _generoService = generoService;
        }

        public async Task<IActionResult> Index(string pesquisarPor = null, string valor = null)
        {
            return View(await Pesquisar(pesquisarPor, valor));
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            return View(await _musicaService.ObterPorId(id));
        }

        public async Task<IActionResult> Cadastrar()
        {
            var musicaViewModel = new MusicaViewModel();
            await PopularSelectList(musicaViewModel);
            return View(musicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(MusicaViewModel musicaViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularSelectList(musicaViewModel);
                return View(musicaViewModel);
            }

            var musicaResponse = await _musicaService.Adicionar(musicaViewModel);

            if (ResponsePossuiErros(musicaResponse.ResponseResult))
            {
                await PopularSelectList(musicaResponse);
                return View(musicaResponse);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            var musicaViewModel = await _musicaService.ObterPorId(id);
            await PopularSelectList(musicaViewModel);
            return View(musicaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, MusicaViewModel musicaViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularSelectList(musicaViewModel);
                return View(musicaViewModel);
            }

            var musicaResponse = await _musicaService.Atualizar(id, musicaViewModel);

            if (ResponsePossuiErros(musicaResponse.ResponseResult))
            {
                await PopularSelectList(musicaResponse);
                return View(musicaResponse);
            }

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

        private async Task PopularSelectList(MusicaViewModel musicaViewModel)
        {
            musicaViewModel.Albuns = (await _albumService.ObterTodos()).Select(p => new SelectListItem(p.Nome, p.Id.ToString()));
            musicaViewModel.Generos = (await _generoService.ObterTodos()).Select(p => new SelectListItem(p.Nome, p.Id.ToString()));
        }
    }
}
