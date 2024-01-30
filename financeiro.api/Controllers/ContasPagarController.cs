using financeiro.api.Controllers.Base;
using financeiro.dominio.Interfaces.App;
using financeiro.dominio.ViewModels;
using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasPagarController : BaseController
    {
        private readonly IContaPagarApp _contaPagarApp;

        public ContasPagarController(IHandle<NotificacaoEvento> notificacao, IContaPagarApp contaPagarApp) : base(notificacao)
        {
            _contaPagarApp = contaPagarApp;
        }

        [HttpGet("")]
        [ProducesResponseType<ContasPagarResultViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscarContasPagar([FromQuery] int mes, [FromQuery] int ano, [FromQuery] int? idCartao = 0)
        {
            var retorno = await _contaPagarApp.BuscarContasPagarAsync(mes, ano, idCartao);
            return Ok(retorno);
        }

        [HttpPost("")]
        [ProducesResponseType<ContasPagarResultViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersistirContaPagar([FromBody] ContaPagarInputViewModel contaPagarViewModel)
        {


            var result = _contaPagarApp.PersisteContaPagarAsync(contaPagarViewModel);
            return CreateResponse(result);
        }
    }
}
