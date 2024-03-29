﻿using financeiro.dominio.ViewModels;

namespace financeiro.dominio.Interfaces.App
{
    public interface IContaPagarApp
    {
        Task<List<ContasPagarResultViewModel>> BuscarContasPagarAsync(int mes, int ano, int? idCartao);
        Task<List<ContasPagarResultViewModel>> PersisteContaPagarAsync(ContaPagarInputViewModel contaPagarViewModel);

    }
}
