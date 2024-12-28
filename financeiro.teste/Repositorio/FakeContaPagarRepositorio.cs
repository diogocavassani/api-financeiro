using Bogus;
using financeiro.dominio.Entidades;
using financeiro.dominio.Entidades.ContasPagar;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominio.ViewModels;

namespace financeiro.infra.Repositorio
{
    public class FakeContaPagarRepositorio : IContaPagarRepositorio
    {
        private readonly IList<ContaPagarCartao> _contasPagarCartao;

        public FakeContaPagarRepositorio()
        {
            var contaPagarId = 0;
            _contasPagarCartao = new Faker<ContaPagarCartao>("pt-BR").StrictMode(false)
                .RuleFor(p => p.IdContaPagar, f => contaPagarId++)
                .RuleFor(p => p.ParcelaAtual, f => f.Random.Number())
                .RuleFor(p => p.TotalParcela, f => f.Random.Number())
                .RuleFor(p => p.Descricao, f => f.Random.Words(2))
                .RuleFor(p => p.Valor, f => f.Finance.Amount())
                .RuleFor(p => p.DataLancamento, f => f.Date.Recent())
                .RuleFor(p => p.DataVencimento, f => f.Date.Future())
                .RuleFor(p => p.FlCancelado, f => f.Random.Bool())
                .RuleFor(p => p.IdCartao, f => f.Random.Int())
                .Generate(100);
        }

        public async Task AdicionarAsync(ContaPagar contaPagar)
        {

        }

        public async Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? cartao)
        {
            var query = _contasPagarCartao
                .Where(p => p.DataVencimento.Month == mes && p.DataVencimento.Year == ano && p.FlCancelado == false).AsQueryable();

            if (cartao is not null && cartao > 0)
                query = query.Where(p => p.IdCartao == cartao);

            return query.Select(p =>
            new ContasPagarResultViewModel(
                p.Descricao,
                p.TotalParcela,
                p.Valor,
                p.IdCartao,
                p.DataVencimento,
                p.DataLancamento
                )).ToList();
        }
    }
}
