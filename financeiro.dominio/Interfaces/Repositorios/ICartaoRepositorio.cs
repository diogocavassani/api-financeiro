using financeiro.dominio.Entidades;
using financeiro.dominio.ViewModels;

namespace financeiro.dominio.Interfaces.Repositorios
{
    public interface ICartaoRepositorio
    {
        Task AdicionarAsync(Cartao cartao);
        Task<List<CartaoResultViewModel>> ObterCartoesAsync();
        Task<Cartao?> BuscarPorIdAsync(int idCartao);
    }
}
