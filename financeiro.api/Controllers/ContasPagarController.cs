using Microsoft.AspNetCore.Mvc;

namespace financeiro.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContasPagarController : ControllerBase
    {

        [HttpGet("")]
        public async Task<IActionResult> BuscarContasPagar()
        {

            return Ok("");
        }
    }
}
