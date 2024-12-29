using financeiro.dominio.Enum;

namespace financeiro.dominio.Entidades
{
    public abstract class ContaPagar
    {

        public int IdContaPagar { get; protected set; }
        public ETipoPagamento TipoContaPagar { get; protected set; }
        public int ParcelaAtual { get; protected set; } = 1;
        public int TotalParcela { get; protected set; } = 1;
        public string Descricao { get; protected set; }
        public decimal Valor { get; protected set; }
        public DateTime DataLancamento { get; protected set; }
        public DateTime DataVencimento { get; protected set; }
        public bool FlCancelado { get; protected set; }

    }
}
