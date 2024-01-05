using financeiro.dominio.Entidade;
using financeiro.dominio.ViewModel;
using financeiro.infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace financeiro.infra.Repositorio
{
    public class ContaPagarRepositorio
    {
        private readonly DataContext _db;

        public ContaPagarRepositorio(DataContext db)
        {
            _db = db;
        }

        public async Task AdicionarAsync(ContaPagar contaPagar)
        {
            await _db.AddAsync(contaPagar);
            await _db.SaveChangesAsync();
        }

        public Task<List<ContasPagarResultViewModel>> BuscarContasPagar(int mes, int ano, int? cartao)
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
