using Bogus;
using financeiro.dominio.Entidades;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominio.ViewModels;

namespace financeiro.infra.Repositorio
{
    public class FakeCartaoRepositorio : ICartaoRepositorio
    {
        private readonly IList<Cartao> _cartoes;

        public FakeCartaoRepositorio()
        {
            var cartaoId = 0;
            _cartoes = new Faker<Cartao>("pt_BR").StrictMode(false)
                .RuleFor(p => p.IdCartao, f => f.IndexFaker)
                .RuleFor(p => p.DiaVencimentoFatura, f => f.Random.Number(1, 30))
                .RuleFor(p => p.NomeCartao, f => f.Finance.AccountName())
                .RuleFor(p => p.FlExcluido, f => f.Random.Bool()).Generate(100);
        }

        public async Task AdicionarAsync(Cartao cartao)
        {
            
        }

        public async Task<List<CartaoResultViewModel>> ObterCartoesAsync() => _cartoes
            .Where(p => p.FlExcluido == false)
            .Select(p => new CartaoResultViewModel(p.IdCartao, p.NomeCartao, p.DiaVencimentoFatura)).ToList();
        public async Task<Cartao?> BuscarPorIdAsync(int idCartao) => _cartoes.Where(c => c.IdCartao == idCartao && c.FlExcluido == false).FirstOrDefault();


    }
}
