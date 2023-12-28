using financeiro.api.Models;
using financeiro.api.Repositorio;
using financeiro.api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasPagarController : ControllerBase
    {
        private readonly CartaoRepositorio _cartaoRepositorio;
        private readonly ContaPagarRepositorio _contaPagarRepositorio;

        public ContasPagarController(CartaoRepositorio cartaoRepositorio,
            ContaPagarRepositorio contaPagarRepositorio)
        {
            _cartaoRepositorio = cartaoRepositorio;
            _contaPagarRepositorio = contaPagarRepositorio;
        }

        [HttpGet("")]
        public async Task<IActionResult> BuscarContasPagar()
        {

            return Ok("");
        }

        [HttpPost("")]
        [ProducesResponseType<ContasPagarResultViewModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersistirContaPagar([FromBody] ContaPagarInputViewModel contaPagarViewModel)
        {
            if (contaPagarViewModel.ValorTotal == 0)
            {
                return BadRequest(new ResultErrorViewModel("Valor precisa ser maior que 0"));
            }

            if (contaPagarViewModel.IdCartao >= 0)
            {
                var cartao = await _cartaoRepositorio.BuscarPorIdAsync(contaPagarViewModel.IdCartao.Value);
                if (cartao == null)
                    return BadRequest(new ResultErrorViewModel("Cartão não encontrado"));

                cartao.LancarContaPagar(contaPagarViewModel.Descricao, contaPagarViewModel.ValorTotal, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento);

                await _cartaoRepositorio.SalvarDados();

                return NoContent();

            }
            return Ok("");
        }

        [HttpGet("{idContaPagar}")]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<CartaoViewModel>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPorIdContaPagar([FromRoute] int idCartao)
        {
            return Ok();
        }
    }
}
