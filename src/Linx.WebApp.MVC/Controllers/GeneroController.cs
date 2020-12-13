using Linx.WebApp.MVC.Services;
using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Linx.WebApp.MVC.Controllers
{
    public class GeneroController : MainController
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _generoService.ObterTodos());
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            return View(await _generoService.ObterPorId(id));
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(GeneroViewModel generoViewModel)
        {
            if (!ModelState.IsValid) return View(generoViewModel);

            var generoResponse = await _generoService.Adicionar(generoViewModel);

            if (ResponsePossuiErros(generoResponse.ResponseResult)) return View(generoResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            return View(await _generoService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, GeneroViewModel generoViewModel)
        {
            if (!ModelState.IsValid) return View(generoViewModel);

            var generoResponse = await _generoService.Atualizar(id, generoViewModel);

            if (ResponsePossuiErros(generoResponse.ResponseResult)) return View(generoResponse);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remover(Guid id)
        {
            return View(await _generoService.ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmaRemover(Guid id)
        {
            var generoResponse = await _generoService.Remover(id);

            if (ResponsePossuiErros(generoResponse.ResponseResult))
            {
                var genero = await _generoService.ObterPorId(id);
                genero.ResponseResult = generoResponse.ResponseResult;
                return View(genero);
            };

            return RedirectToAction("Index");
        }
    }
}
