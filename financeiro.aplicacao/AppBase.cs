using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.infra.Transacao;

namespace financeiro.aplicacao
{
    public class AppBase
    {
        private readonly UnitOfWork _unitOfWork;
        protected readonly IHandle<NotificacaoEvento> _notificacao;

        public AppBase(UnitOfWork unitOfWork, IHandle<NotificacaoEvento> notificacao)
        {
            _unitOfWork = unitOfWork;
            _notificacao = notificacao;
        }

        public async Task<bool> SalvarDados()
        {
            return await _unitOfWork.SalvarDados();
        }
    }
}
