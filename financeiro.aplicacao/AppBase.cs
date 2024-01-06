using financeiro.infra.Transacao;

namespace financeiro.aplicacao
{
    public class AppBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AppBase(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SalvarDados()
        {
            return await _unitOfWork.SalvarDados();
        }
    }
}
