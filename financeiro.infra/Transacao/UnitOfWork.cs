using financeiro.infra.Contexto;

namespace financeiro.infra.Transacao
{
    public class UnitOfWork
    {
        private readonly DataContext _db;

        public UnitOfWork(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task<bool> SalvarDados()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
