using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Controllers
{
    public class AlbumController : MainController
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistaService _artistaService;

        public AlbumController(IAlbumService albumService, IArtistaService artistaService)
        {
            _albumService = albumService;
            _artistaService = artistaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _albumService.ObterTodos());
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            return View(await _albumService.ObterPorId(id));
        }

        public async Task<IActionResult> Cadastrar()
        {
            var albumViewModel = new AlbumViewModel();
            await PopularSelectList(albumViewModel);
            return View(albumViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularSelectList(albumViewModel);
                return View(albumViewModel);
            }

            var albumResponse = await _albumService.Adicionar(albumViewModel);

            if (ResponsePossuiErros(albumResponse.ResponseResult))
            {
                await PopularSelectList(albumViewModel);
                return View(albumResponse);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            var albumViewModel = await _albumService.ObterPorId(id);
            await PopularSelectList(albumViewModel);
            return View(albumViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid)
            {
                await PopularSelectList(albumViewModel);
                return View(albumViewModel);
            }

            var albumResponse = await _albumService.Atualizar(id, albumViewModel);

            if (ResponsePossuiErros(albumResponse.ResponseResult))
            {
                await PopularSelectList(albumViewModel);
                return View(albumResponse);
            }

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

        private async Task PopularSelectList(AlbumViewModel albumViewModel)
        {
            albumViewModel.Artistas = (await _artistaService.ObterTodos()).Select(p => new SelectListItem(p.Nome, p.Id.ToString()));
        }
    }
}
