using Linx.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Linx.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte";
                modelError.Titulo = "Ocorreu um erro!";
                modelError.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelError.Mensagem = "A página que você está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelError.Titulo = "Opa! Página não encontrada";
                modelError.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelError.Mensagem = "Você não tem permissão para fazer isto";
                modelError.Titulo = "Acesso Negado";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
