using financeiro.api.Data;
using financeiro.api.Models;
using financeiro.api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace financeiro.api.Repositorio
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

        public async Task<List<CartaoViewModel>> ObterCartoesAsync() => await _db.Cartoes
            .AsNoTracking()
            .Where(p => p.FlExcluido == false)
            .Select(p => new CartaoViewModel(p.IdCartao, p.NomeCartao, p.DiaVencimentoFatura)).ToListAsync();
        public async Task<Cartao> BuscarPorIdAsync(int idCartao)
        {
            return await _db.Cartoes.Where(c => c.IdCartao == idCartao && c.FlExcluido == false).FirstOrDefaultAsync();
        }

        public async Task SalvarDados()
        {
            await _db.SaveChangesAsync();
        }
    }
}
