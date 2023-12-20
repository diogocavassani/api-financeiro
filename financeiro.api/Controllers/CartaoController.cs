using financeiro.api.Controllers.Base;
using financeiro.api.Data;
using financeiro.api.Models;
using financeiro.api.Repositorio;
using financeiro.api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartaoController : BaseController
    {
        private readonly CartaoRepositorio _cartaoRepositorio;

        public CartaoController(CartaoRepositorio cartaoRepositorio)
        {
            _cartaoRepositorio = cartaoRepositorio;
        }

        [HttpPost("")]
        [ProducesResponseType<CartaoViewModel>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersiteCartao([FromBody] CartaoInputViewModel cartaoViewModel)
        {
            if (string.IsNullOrEmpty(cartaoViewModel.NomeCartao))
            {
                return BadRequest(new ResultErrorViewModel("Nome do cartão é obrigatório"));
            }
            var cartao = new Cartao(cartaoViewModel.NomeCartao ?? "", cartaoViewModel.VencimentoFatura);
            await _cartaoRepositorio.AdicionarAsync(cartao);
            
            return CreatedAtAction(nameof(GetPorIdCartao), 
                new { idCartao = cartao.IdCartao }, 
                new CartaoViewModel(cartao.IdCartao, cartao.NomeCartao, cartao.DataVencimentoFatura));
        }

        [HttpGet("")]
        [ProducesResponseType<List<CartaoViewModel>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCartao()
        {
           var listCartoes = await _cartaoRepositorio.ObterCartoesAsync();

            return Ok(listCartoes);
        }

        [HttpGet("{idCartao}")]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<CartaoViewModel>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPorIdCartao([FromRoute]int idCartao)
        {
            if (idCartao == 0)
            {
                return NotFound(new ResultErrorViewModel("Cartão não encontrado"));
            }
            var cartao = await _cartaoRepositorio.BuscarPorIdAsync(idCartao);

            if (cartao == null)
            {
                return NotFound(new ResultErrorViewModel("Cartão não encontrado"));
            }

            var cartaoViewModel = new CartaoViewModel(cartao.IdCartao, cartao.NomeCartao, cartao.DataVencimentoFatura);
            return Ok(cartaoViewModel);
        }

        [HttpDelete("{idCartao}")]
        [ProducesResponseType<ResultErrorViewModel>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarCartao([FromRoute]int idCartao)
        {
            if(idCartao == 0)
            {
                return BadRequest(new ResultErrorViewModel("Cartão não encontrado"));
            }
            var cartao = await _cartaoRepositorio.BuscarPorIdAsync(idCartao);

            if(cartao == null)
            {
                return BadRequest(new ResultErrorViewModel("Cartão não encontrado"));
            }

            cartao.Excluir();
            await _cartaoRepositorio.SalvarDados();
            return NoContent();
        }
    }
}
