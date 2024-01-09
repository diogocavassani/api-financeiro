using financeiro.dominio.Entidades;
using financeiro.dominio.Repositorios;
using financeiro.dominio.ViewModels;
using financeiro.infra.Repositorio;
using financeiro.infra.Transacao;

namespace financeiro.aplicacao.App
{
    public class ContaPagarApp : AppBase
    {
        private readonly IContaPagarRepositorio _contaPagarRepositorio;
        private readonly ICartaoRepositorio _cartaoRepositorio;

        public ContaPagarApp(UnitOfWork unitOfWork, IContaPagarRepositorio contaPagarRepositorio, ICartaoRepositorio cartaoRepositorio) : base(unitOfWork)
        {
            _contaPagarRepositorio = contaPagarRepositorio;
            _cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? idCartao)
        {
            return await _contaPagarRepositorio.BuscarContasPagarAsync(mes, ano, idCartao);
        }

        public async Task<ContasPagarResultViewModel> PersisteContaPagarAsync(ContaPagarInputViewModel contaPagarViewModel)
        {
            //TODO:Precisa refatorar após o lançamento de notificações. Retornar sempre as contas criadas no banco. Atualmente não da pra saber se criou ou não.
            if (contaPagarViewModel.IdCartao >= 0)
            {
                var cartao = await _cartaoRepositorio.BuscarPorIdAsync(contaPagarViewModel.IdCartao.Value);
                if (cartao == null)
                    return null;

                cartao.LancarContaPagar(contaPagarViewModel.Descricao, contaPagarViewModel.ValorTotal, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento);

                await SalvarDados();

                return null;

            }

            if (contaPagarViewModel.TotalParcelas > 1)
            {
                var valorParcela = Math.Round(contaPagarViewModel.ValorTotal / contaPagarViewModel.TotalParcelas, 2);

                for (int parcela = 0; parcela < contaPagarViewModel.TotalParcelas; parcela++)
                {
                    var contaPagar = new ContaPagar(contaPagarViewModel.Descricao, valorParcela, parcela + 1, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento.AddMonths(parcela + 1));
                    await _contaPagarRepositorio.AdicionarAsync(contaPagar);
                    await SalvarDados();
                }
                return null;
            }

            var contaPagarUnica = new ContaPagar(contaPagarViewModel.Descricao, 1, 1, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento);
            await _contaPagarRepositorio.AdicionarAsync(contaPagarUnica);
            await SalvarDados();
            return null;
        }
    }
}
