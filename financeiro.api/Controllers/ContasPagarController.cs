using financeiro.aplicacao.App;
using financeiro.dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasPagarController : ControllerBase
    {
        private readonly CartaoRepositorio _cartaoRepositorio;
        private readonly ContaPagarApp _contaPagarApp;

        public ContasPagarController(ContaPagarApp cartaoApp,
            ContaPagarRepositorio contaPagarRepositorio)
        {
            _cartaoRepositorio = cartaoRepositorio;
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

            if (contaPagarViewModel.TotalParcelas > 1)
            {
                var valorParcela = Math.Round(contaPagarViewModel.ValorTotal / contaPagarViewModel.TotalParcelas, 2);

                for (int parcela = 0; parcela < contaPagarViewModel.TotalParcelas; parcela++)
                {
                    var contaPagar = new ContaPagar(contaPagarViewModel.Descricao, valorParcela, parcela + 1, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento.AddMonths(parcela + 1));
                    await _contaPagarRepositorio.AdicionarAsync(contaPagar);
                }
                return NoContent();
            }

            var contaPagarUnica = new ContaPagar(contaPagarViewModel.Descricao, 1, 1, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento);
            await _contaPagarRepositorio.AdicionarAsync(contaPagarUnica);
            return NoContent();
        }
    }
}
