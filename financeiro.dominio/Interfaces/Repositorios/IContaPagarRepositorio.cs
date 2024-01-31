using financeiro.dominio.Entidades;
using financeiro.dominio.ViewModels;

namespace financeiro.dominio.Interfaces.Repositorios
{
    public interface IContaPagarRepositorio
    {
        Task AdicionarAsync(ContaPagar contaPagar);
        Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? cartao);

    }
}
