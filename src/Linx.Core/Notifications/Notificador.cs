using System.Collections.Generic;
using System.Linq;

namespace Linx.Core.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacaos;

        public Notificador()
        {
            _notificacaos = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao) => _notificacaos.Add(notificacao);

        public List<Notificacao> ObterNotificacoes() => _notificacaos;

        public bool TemNotificacao() => _notificacaos.Any();
    }
}
