using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Controllers
{
    public class ArtistaController : MainController
    {
        private readonly IArtistaService _artistaService;

        public ArtistaController(IArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _artistaService.ObterTodos());
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            return View(await _artistaService.ObterPorId(id));
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(ArtistaViewModel artistaViewModel)
        {
            if (!ModelState.IsValid) return View(artistaViewModel);

            var artistaResponse = await _artistaService.Adicionar(artistaViewModel);

            if (ResponsePossuiErros(artistaResponse.ResponseResult)) return View(artistaResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            return View(await _artistaService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, ArtistaViewModel artistaViewModel)
        {
            if (!ModelState.IsValid) return View(artistaViewModel);

            var artistaResponse = await _artistaService.Atualizar(id, artistaViewModel);

            if (ResponsePossuiErros(artistaResponse.ResponseResult)) return View(artistaResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remover(Guid id)
        {
            return View(await _artistaService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmaRemover(Guid id)
        {
            var artistaResponse = await _artistaService.Remover(id);

            if (ResponsePossuiErros(artistaResponse.ResponseResult))
            {
                var artista = await _artistaService.ObterPorId(id);
                artista.ResponseResult = artistaResponse.ResponseResult;
                return View(artista);
            };

            return RedirectToAction("Index");
        }
    }
}
