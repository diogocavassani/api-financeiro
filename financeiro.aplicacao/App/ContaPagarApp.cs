using financeiro.dominio.ViewModel;
using financeiro.infra.Repositorio;

namespace financeiro.aplicacao.App
{
    public class ContaPagarApp
    {
        private readonly ContaPagarRepositorio _contaPagarRepositorio;
        private readonly CartaoRepositorio _cartaoRepositorio;

        public ContaPagarApp(ContaPagarRepositorio contaPagarRepositorio, CartaoRepositorio cartaoRepositorio)
        {
            _contaPagarRepositorio = contaPagarRepositorio;
            _cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? idCartao)
        {
            return await _contaPagarRepositorio.BuscarContasPagarAsync(mes, ano, idCartao);
        }
    }
}
