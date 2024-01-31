using financeiro.dominio.Entidades;
using financeiro.dominio.Enum;
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
            switch (contaPagarViewModel.TipoPagamento)
            {
                case ETipoPagamento.Cartao:
                    var cartao = await _cartaoRepositorio.BuscarPorIdAsync(contaPagarViewModel.IdCartao.Value);
                    if (cartao == null)
                    {
                        await _notificacao.Handle(new NotificacaoEvento("PersisteContaPagarAsync", "Cartão não existe"));
                        return null;
                    }
                    retorno = cartao.LancarContaPagar(contaPagarViewModel.Descricao, contaPagarViewModel.ValorParcela, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento);
                    break;
                case ETipoPagamento.Dinheiro:
                    break;
                case ETipoPagamento.Pix:
                    break;
                case ETipoPagamento.Carne:
                    for (int parcela = 1; parcela <= contaPagarViewModel.TotalParcelas; parcela++)
                    {
                        var contaPagar = new ContaPagar(
                            contaPagarViewModel.Descricao,
                            contaPagarViewModel.ValorParcela,
                            parcela,
                            contaPagarViewModel.TotalParcelas,
                            contaPagarViewModel.DataLancamento,
                            contaPagarViewModel.DataVencimento.AddMonths(parcela));
                        await _contaPagarRepositorio.AdicionarAsync(contaPagar);
                        retorno.Add(new ContasPagarResultViewModel(contaPagar.Descricao, contaPagar.TotalParcela, contaPagar.Valor, null, contaPagar.DataVencimento, contaPagar.DataLancamento));
                    }
                    break;
                default:
                    break;
            }

            if (await SalvarDados())
            {
                return retorno;
            }
            return null;
        }
    }
}
