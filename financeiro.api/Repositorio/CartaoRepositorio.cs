using financeiro.api.Data;
using financeiro.api.Models;

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
    }
}
