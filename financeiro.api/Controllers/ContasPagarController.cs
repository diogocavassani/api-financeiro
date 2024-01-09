using financeiro.aplicacao.App;
using financeiro.dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasPagarController : ControllerBase
    {
        private readonly ContaPagarApp _contaPagarApp;

        public ContasPagarController(ContaPagarApp cartaoApp)
        {
            _contaPagarApp = cartaoApp;
        }

        [HttpGet("")]
        [ProducesResponseType<ContasPagarResultViewModel>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscarContasPagar([FromQuery] int mes, [FromQuery] int ano, [FromQuery] int? idCartao = 0)
        {
            if (mes == 0 || ano == 0)
                return BadRequest(new ResultErrorViewModel("Mês e ano precisam estar preenchidos"));

            var retorno = await _contaPagarApp.BuscarContasPagarAsync(mes, ano, idCartao);
            return Ok(retorno);
        }

        [HttpPost("")]
        [ProducesResponseType<ContasPagarResultViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersistirContaPagar([FromBody] ContaPagarInputViewModel contaPagarViewModel)
        {
            if (contaPagarViewModel.ValorTotal == 0)
            {
                return BadRequest(new ResultErrorViewModel("Valor precisa ser maior que 0"));
            }

            var result = _contaPagarApp.PersisteContaPagarAsync(contaPagarViewModel);
            return NoContent();
        }
    }
}
