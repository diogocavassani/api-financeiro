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
        public async Task<IActionResult> PersiteCartao([FromBody] CartaoViewModel cartaoViewModel)
        {
            if (string.IsNullOrEmpty(cartaoViewModel.NomeCartao))
            {
                return BadRequest("Nome do cartão obrigatório");
            }
            var cartao = new Cartao(cartaoViewModel.NomeCartao ?? "", cartaoViewModel.VencimentoFatura);
            await _cartaoRepositorio.AdicionarAsync(cartao);
            return Created("", null);
        }
    }
}
