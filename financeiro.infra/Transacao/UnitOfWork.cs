using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.dominioNucleoCompartilhado;
using financeiro.infra.Contexto;

namespace financeiro.infra.Transacao
{
    public class UnitOfWork
    {
        private readonly DataContext _db;
        protected readonly IHandle<NotificacaoEvento> _notificacao;
        public UnitOfWork(DataContext dataContext, IHandle<NotificacaoEvento> notificacao)
        {
            _db = dataContext;
            _notificacao = notificacao;
        }

        public async Task<bool> SalvarDados()
        {
            try
            {
                if (_notificacao.ExisteNotificacoes()) return false;
                
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
