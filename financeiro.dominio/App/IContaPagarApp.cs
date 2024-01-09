using financeiro.dominio.ViewModels;

namespace financeiro.dominio.App
{
    public interface IContaPagarApp
    {
        Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? idCartao);
        Task<ContasPagarResultViewModel> PersisteContaPagarAsync(ContaPagarInputViewModel contaPagarViewModel);

    }
}
