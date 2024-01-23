using financeiro.dominio.App;
using financeiro.dominio.Entidades;
using financeiro.dominio.Repositorios;
using financeiro.dominio.ViewModels;
using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.infra.Transacao;

namespace financeiro.aplicacao.App
{
    public class CartaoApp : AppBase, ICartaoApp
    {
        private readonly ICartaoRepositorio _cartaoRepositorio;

        public CartaoApp(UnitOfWork unitOfWork, IHandle<NotificacaoEvento> notificacao, ICartaoRepositorio cartaoRepositorio) : base(unitOfWork, notificacao)
        {
            _cartaoRepositorio = cartaoRepositorio;
        }

        public async Task<CartaoResultViewModel> BuscarPorIdAsync(int idCartao)
        {
            if (idCartao == 0)
            {
                await _notificacao.Handle(new NotificacaoEvento("BuscarPorIdAsync", "Cartão não encontrado"));
                return null;
            }
            var cartao = await _cartaoRepositorio.BuscarPorIdAsync(idCartao);

            return cartao != null ?
                new CartaoResultViewModel(cartao.IdCartao, cartao.NomeCartao, cartao.DiaVencimentoFatura) : null;
        }

        public async Task ExcluirCartaoAsync(int idCartao)
        {
            if (idCartao == 0)
            {
                await _notificacao.Handle(new NotificacaoEvento("BuscarPorIdAsync", "Cartão não encontrado"));
                return;
            }
            var cartao = await _cartaoRepositorio.BuscarPorIdAsync(idCartao);
            if (cartao == null)
            {
                await _notificacao.Handle(new NotificacaoEvento("BuscarPorIdAsync", "Cartão não encontrado"));
                return;
            }

            cartao.Excluir();

            await SalvarDados();

        }

        public async Task<List<CartaoResultViewModel>> ObterCartoesAsync()
        {
            return await _cartaoRepositorio.ObterCartoesAsync();
        }

        public async Task<CartaoResultViewModel> PersisteCartaoAsync(CartaoInputViewModel cartaoViewModel)
        {
            if (string.IsNullOrEmpty(cartaoViewModel.NomeCartao))
            {
                await _notificacao.Handle(new NotificacaoEvento("PersisteCartaoAsync", "Nome do cartão é obrigatório"));
                return null;
            }
            var cartao = new Cartao(cartaoViewModel.NomeCartao, cartaoViewModel.DiaVencimentoFatura);
            await _cartaoRepositorio.AdicionarAsync(cartao);
            await SalvarDados();
            return new CartaoResultViewModel(cartao.IdCartao, cartao.NomeCartao, cartao.DiaVencimentoFatura);
        }
    }
}
