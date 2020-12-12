using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linx.Core.Data;
using Linx.Core.DomainObjects;
using Linx.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Linx.Player.API.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomBadRequest()
        {
            return BadRequest(new
            {
                errors = _notificador.ObterNotificacoes().Select(e => e.Mensagem)
            });
        }

        protected async Task<bool> Commit<T>(IRepository<T> repositorio) where T : Entity
        {
            if (_notificador.ObterNotificacoes().Count > 0) return false;

            var resultado = await repositorio.UnitOfWork.Commit();

            if (!resultado) _notificador.Handle(new Notificacao("Falha ao salvar no banco de dados!"));

            return resultado;
        }
    }
}
