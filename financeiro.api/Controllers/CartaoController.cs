using financeiro.api.Controllers.Base;
using financeiro.aplicacao.App;
using financeiro.dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartaoController : BaseController
    {
        private readonly CartaoApp _cartaoApp;

        public CartaoController(CartaoApp cartaoApp)
        {
            _cartaoApp = cartaoApp;
        }

        [HttpPost("")]
        [ProducesResponseType<CartaoResultViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersiteCartao([FromBody] CartaoInputViewModel cartaoViewModel)
        {
            //TODO: Passar validação para camada de APP.
            if (string.IsNullOrEmpty(cartaoViewModel.NomeCartao))
            {
                return BadRequest(new ResultErrorViewModel("Nome do cartão é obrigatório"));
            }
            var cartaoResult = await _cartaoApp.PersisteCartaoAsync(cartaoViewModel);


            return CreatedAtAction(nameof(GetPorIdCartao),
                new { cartaoResult.idCartao },
                cartaoResult);
        }

        [HttpGet("")]
        [ProducesResponseType<List<CartaoResultViewModel>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCartao()
        {
            var listCartoes = await _cartaoApp.ObterCartoesAsync();

            return Ok(listCartoes);
        }

        [HttpGet("{idCartao}")]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<CartaoResultViewModel>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPorIdCartao([FromRoute] int idCartao)
        {
            if (idCartao == 0)
            {
                return NotFound(new ResultErrorViewModel("Cartão não encontrado"));
            }
            var cartaoResult = await _cartaoApp.BuscarPorIdAsync(idCartao);

            if (cartaoResult == null)
            {
                return NotFound(new ResultErrorViewModel("Cartão não encontrado"));
            }

            return Ok(cartaoResult);
        }

        [HttpDelete("{idCartao}")]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarCartao([FromRoute] int idCartao)
        {            
            var flSucesso = await _cartaoApp.ExcluirCartaoAsync(idCartao);
            if (!flSucesso)
                return BadRequest(new ResultErrorViewModel("Cartão não encontrado"));
            
            return NoContent();
        }
    }
}
