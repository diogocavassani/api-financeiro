using financeiro.aplicacao.App;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.dominioNucleoCompartilhado;
using financeiro.infra.Repositorio;
using financeiro.infra.Transacao;
using financeiro.dominio.ViewModels;

namespace financeiro.teste.Aplication
{

    public class CartaoAppTestes
    {
        private readonly ICartaoRepositorio _cartaoRepositorio;
        private readonly UnitOfWork unitOfWork;
        private readonly IHandle<NotificacaoEvento> notificacao;

        public CartaoAppTestes()
        {
            _cartaoRepositorio = new FakeCartaoRepositorio();

        }

        [Fact]
        public async Task Dado_um_cartao_valido_deve_retornar_os_dados_do_cartao()
        {
            var cartaoApp = new CartaoApp(unitOfWork, notificacao, _cartaoRepositorio);
            var cartaoViewModel = new CartaoInputViewModel("Teste", 20);
            var teste = await cartaoApp.PersisteCartaoAsync(cartaoViewModel);
        }
    }
}
