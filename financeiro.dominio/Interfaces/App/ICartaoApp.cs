﻿using financeiro.dominio.ViewModels;

namespace financeiro.dominio.Interfaces.App
{
    public interface ICartaoApp
    {
        Task<CartaoResultViewModel?> BuscarPorIdAsync(int idCartao);
        Task ExcluirCartaoAsync(int idCartao);
        Task<List<CartaoResultViewModel>> ObterCartoesAsync();
        Task<CartaoResultViewModel> PersisteCartaoAsync(CartaoInputViewModel cartaoViewModel);
    }
}
