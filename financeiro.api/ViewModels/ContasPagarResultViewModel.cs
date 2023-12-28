﻿namespace financeiro.api.ViewModels
{
    public record ContasPagarResultViewModel(string Descricao, int TotalParcelas, decimal ValorTotal, int? IdCartao, DateTime DataVencimento, DateTime? DataLancamento);
}
