﻿using financeiro.dominio.Enum;
using System.Text.Json.Serialization;

namespace financeiro.dominio.Entidades.ContasPagar
{
    public class ContaPagarCartao : ContaPagar
    {
        protected ContaPagarCartao()
        {
            TipoContaPagar = ETipoPagamento.Cartao;
        }
        public ContaPagarCartao(string descricao, decimal valorParcela, int totalParcelas, int parcelaAtual, DateTime dataLancamento, DateTime dataVencimento, Cartao cartao)
        {
            Descricao = descricao;
            Valor = valorParcela;
            TotalParcela = totalParcelas;
            ParcelaAtual = parcelaAtual;
            DataLancamento = dataLancamento;
            DataVencimento = dataVencimento;
            Cartao = cartao;
            TipoContaPagar = ETipoPagamento.Cartao;

        }
        public int IdCartao { get; private set; }
        [JsonIgnore]
        public virtual Cartao Cartao { get; set; } = null!;
    }
}
