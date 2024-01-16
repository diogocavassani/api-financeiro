using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected readonly IHandle<NotificacaoEvento> _notificacao;

        public BaseController(IHandle<NotificacaoEvento> notificacao)
        {
            _notificacao = notificacao;
        }
    }
}
