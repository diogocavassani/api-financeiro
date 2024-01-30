using financeiro.dominio.Entidades;
using financeiro.dominio.Interfaces.App;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominio.ViewModels;
using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.infra.Transacao;

namespace financeiro.aplicacao.App
{
    public class ContaPagarApp : AppBase, IContaPagarApp
    {
        private readonly IContaPagarRepositorio _contaPagarRepositorio;
        private readonly ICartaoRepositorio _cartaoRepositorio;

        public ContaPagarApp(UnitOfWork unitOfWork, IHandle<NotificacaoEvento> notificacao, IContaPagarRepositorio contaPagarRepositorio, ICartaoRepositorio cartaoRepositorio) : base(unitOfWork, notificacao)
        {
            _contaPagarRepositorio = contaPagarRepositorio;
            _cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? idCartao)
        {
            if (mes == 0 || ano == 0)
            {
                await _notificacao.Handle(new NotificacaoEvento("BuscarContasPagarAsync", "Mês e ano precisam estar preenchidos"));
                return null;
            }

            return await _contaPagarRepositorio.BuscarContasPagarAsync(mes, ano, idCartao);
        }

        public async Task<List<ContasPagarResultViewModel>> PersisteContaPagarAsync(ContaPagarInputViewModel contaPagarViewModel)
        {
            if (contaPagarViewModel.ValorTotal == 0)
            {
                await _notificacao.Handle(new NotificacaoEvento("PersisteContaPagarAsync", "Valor precisa ser maior que 0"));
                return null;
            }
            var retorno = new List<ContasPagarResultViewModel>();
            if (contaPagarViewModel.IdCartao > 0)
            {
                var cartao = await _cartaoRepositorio.BuscarPorIdAsync(contaPagarViewModel.IdCartao.Value);
                if (cartao == null)
                {
                    await _notificacao.Handle(new NotificacaoEvento("PersisteContaPagarAsync", "Valor precisa ser maior que 0"));
                    return null;
                }
                for (var parcelaAtual = 1; parcelaAtual <= contaPagarViewModel.TotalParcelas; parcelaAtual++)
                {
                    var contaPagar = new ContaPagar(
                        contaPagarViewModel.Descricao,
                        contaPagarViewModel.ValorParcela,
                        contaPagarViewModel.TotalParcelas,
                        parcelaAtual,
                        contaPagarViewModel.DataLancamento,
                        contaPagarViewModel.DataVencimento.AddMonths(parcelaAtual).Month,
                        contaPagarViewModel.DataVencimento.Year,
                        cartao);
                    await _contaPagarRepositorio.AdicionarAsync(contaPagar);
                    retorno.Add(new ContasPagarResultViewModel(contaPagar.Descricao, contaPagar.TotalParcela, contaPagar.Valor, contaPagar.Cartao.IdCartao, contaPagar.DataVencimento, contaPagar.DataLancamento));
                }
            }
            else
            {
                for (int parcela = 1; parcela <= contaPagarViewModel.TotalParcelas; parcela++)
                {
                    var contaPagar = new ContaPagar(contaPagarViewModel.Descricao, contaPagarViewModel.ValorParcela, parcela, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento, contaPagarViewModel.DataVencimento.AddMonths(parcela));
                    await _contaPagarRepositorio.AdicionarAsync(contaPagar);
                    retorno.Add(new ContasPagarResultViewModel(contaPagar.Descricao, contaPagar.TotalParcela, contaPagar.Valor, contaPagar.Cartao.IdCartao, contaPagar.DataVencimento, contaPagar.DataLancamento));
                }
            }


            if (await SalvarDados())
            {
                return retorno;
            }
            return null;
        }
    }
}
