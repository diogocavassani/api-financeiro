using financeiro.dominio.Entidade;
using financeiro.dominio.ViewModel;
using financeiro.infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace financeiro.infra.Repositorio
{
    public class CartaoRepositorio
    {
        private readonly DataContext _db;

        public CartaoRepositorio(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task AdicionarAsync(Cartao cartao)
        {
            await _db.AddAsync(cartao);
            await _db.SaveChangesAsync();
        }

        public async Task<List<CartaoResultViewModel>> ObterCartoesAsync() => await _db.Cartoes
            .AsNoTracking()
            .Where(p => p.FlExcluido == false)
            .Select(p => new CartaoResultViewModel(p.IdCartao, p.NomeCartao, p.DiaVencimentoFatura)).ToListAsync();
        public async Task<Cartao?> BuscarPorIdAsync(int idCartao) => await _db.Cartoes.Where(c => c.IdCartao == idCartao && c.FlExcluido == false).FirstOrDefaultAsync();

        public async Task SalvarDados() => await _db.SaveChangesAsync();
    }
}
