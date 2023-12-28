using financeiro.api.Data;
using financeiro.api.Models;

namespace financeiro.api.Repositorio
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
    }
}
