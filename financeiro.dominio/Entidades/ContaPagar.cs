﻿using System.Text.Json.Serialization;

namespace financeiro.dominio.Entidades
{
    public class ContaPagar
    {
        protected ContaPagar()
        {

        }
        public ContaPagar(string descricao, decimal valorTotal, int totalParcelas, int parcela, DateTime dataLancamento, DateTime dataVencimento)
        {
            Descricao = descricao;
            Valor = valorTotal;
            DataLancamento = dataLancamento;
            DataVencimento = dataVencimento;
            TotalParcela = totalParcelas;
            ParcelaAtual = parcela;
        }

        public ContaPagar(string descricao, decimal valorParcela, int totalParcelas, int parcelaAtual, DateTime dataLancamento, DateTime dataVencimento, Cartao cartao)
        {
            Descricao = descricao;
            Valor = valorParcela;
            TotalParcela = totalParcelas;
            ParcelaAtual = parcelaAtual;
            DataLancamento = dataLancamento;
            DataVencimento = dataVencimento;
            Cartao = cartao;
        }

        public int IdContaPagar { get; private set; }
        public int ParcelaAtual { get; private set; } = 1;
        public int TotalParcela { get; private set; } = 1;
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataLancamento { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public bool FlCancelado { get; private set; }
        public int? IdCartao { get; private set; }
        [JsonIgnore]
        public virtual Cartao Cartao { get; set; }
    }
}
