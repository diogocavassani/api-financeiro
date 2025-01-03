﻿using financeiro.dominio.Enum;

namespace financeiro.dominio.ViewModels
{
    public class ContaPagarInputViewModel
    {
        public required string Descricao { get; set; }
        public int TotalParcelas { get; set; } = 1;
        public decimal ValorTotal { get; set; }
        public int? IdCartao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal ValorParcela => TotalParcelas > 0 ? ValorTotal / TotalParcelas : ValorTotal;
        public ETipoPagamento TipoPagamento { get; set; }
    }
}