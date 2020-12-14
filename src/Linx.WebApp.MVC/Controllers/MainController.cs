using Linx.WebApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Linx.WebApp.MVC.Controllers
{
    public abstract class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Any())
            {
                foreach (var mensagem in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}
