using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Controllers
{
    public class AlbumController : MainController
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _albumService.ObterTodos());
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            return View(await _albumService.ObterPorId(id));
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid) return View(albumViewModel);

            var albumResponse = await _albumService.Adicionar(albumViewModel);

            if (ResponsePossuiErros(albumResponse.ResponseResult)) return View(albumResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            return View(await _albumService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid) return View(albumViewModel);

            var albumResponse = await _albumService.Atualizar(id, albumViewModel);

            if (ResponsePossuiErros(albumResponse.ResponseResult)) return View(albumResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remover(Guid id)
        {
            return View(await _albumService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmaRemover(Guid id)
        {
            var artista = await _albumService.ObterPorId(id);

            var albumResponse = await _albumService.Remover(id);

            if (ResponsePossuiErros(albumResponse.ResponseResult))
            {
                artista.ResponseResult = albumResponse.ResponseResult;
                return View(artista);
            };

            return RedirectToAction("Index");
        }
    }
}
