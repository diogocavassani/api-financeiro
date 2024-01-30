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
    public class CartaoController : BaseController
    {
        private readonly ICartaoApp _cartaoApp;

        public CartaoController(IHandle<NotificacaoEvento> notificacao, ICartaoApp cartaoApp) : base(notificacao)
        {
            _cartaoApp = cartaoApp;
        }

        [HttpPost("")]
        [ProducesResponseType<CartaoResultViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersiteCartao([FromBody] CartaoInputViewModel cartaoViewModel)
        {
            var cartaoResult = await _cartaoApp.PersisteCartaoAsync(cartaoViewModel);
            return CreateResponse(cartaoResult, 201);
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

            var cartaoResult = await _cartaoApp.BuscarPorIdAsync(idCartao);
            return CreateResponse(cartaoResult);
        }

        [HttpDelete("{idCartao}")]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarCartao([FromRoute] int idCartao)
        {
            await _cartaoApp.ExcluirCartaoAsync(idCartao);
            return CreateResponse(null, 204);
        }
    }
}
