using financeiro.dominio.Entidades;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominio.ViewModels;
using financeiro.infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace financeiro.infra.Repositorio
{
    public class ContaPagarRepositorio : IContaPagarRepositorio
    {
        private readonly DataContext _db;

        public ContaPagarRepositorio(DataContext db)
        {
            _db = db;
        }

        public async Task AdicionarAsync(ContaPagar contaPagar)
        {
            await _db.AddAsync(contaPagar);
        }

        public Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? cartao)
        {
            var query = _db.ContasPagar.AsNoTracking()
                .Where(p => p.DataVencimento.Month == mes && p.DataVencimento.Year == ano)
                .Where(p => p.FlCancelado == false);

            if (cartao != null && cartao > 0)
                query = query.Where(p => p.IdCartao == cartao);

            return query.Select(p =>
            new ContasPagarResultViewModel(
                p.Descricao,
                p.TotalParcela,
                p.Valor,
                p.IdCartao,
                p.DataVencimento,
                p.DataLancamento
                )).ToListAsync();
        }
    }
}
