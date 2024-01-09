using financeiro.dominio.ViewModels;

namespace financeiro.dominio.App
{
    public interface ICartaoApp
    {
        Task<CartaoResultViewModel?> BuscarPorIdAsync(int idCartao);
        Task<bool> ExcluirCartaoAsync(int idCartao);
        Task<List<CartaoResultViewModel>> ObterCartoesAsync();
        Task<CartaoResultViewModel> PersisteCartaoAsync(CartaoInputViewModel cartaoViewModel)
    }
}
