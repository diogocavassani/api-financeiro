using financeiro.dominio.ViewModels;
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

        protected IActionResult CreateResponse(object result, int statusCode = 200)
        {
            if (_notificacao.ExisteNotificacoes())
                return BadRequest(new ResultErrorViewModel(_notificacao.ObterNotificacoes()));

            return StatusCode(statusCode, result);
        }
    }
}
