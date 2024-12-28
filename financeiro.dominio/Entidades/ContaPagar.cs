using financeiro.dominio.Enum;

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
