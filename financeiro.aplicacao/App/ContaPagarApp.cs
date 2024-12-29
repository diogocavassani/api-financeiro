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
                    if (cartao is null)
                    {
                        await _notificacao.Handle(new NotificacaoEvento("PersisteContaPagarAsync", "Cartão não existe"));
                        return null;
                    }
                    var contasPagar = cartao.LancarContaPagar(contaPagarViewModel.Descricao, contaPagarViewModel.ValorParcela, contaPagarViewModel.TotalParcelas, contaPagarViewModel.DataLancamento);
                    retorno.AddRange(contasPagar.Select(p => new ContasPagarResultViewModel(p.Descricao, p.TotalParcela, p.Valor, p.IdCartao, p.DataVencimento, p.DataLancamento)).ToList());
                    break;
                case ETipoPagamento.Dinheiro:
                    break;
                case ETipoPagamento.Pix:
                    break;
                default:
                    break;
            }

            await SalvarDados();

            return retorno;
            

        }
    }
}
