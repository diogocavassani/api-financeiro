
namespace financeiro.api.Models
{
    public class ContaPagar
    {
        protected ContaPagar()
        {
                
        }
        public ContaPagar(string descricao, decimal valorTotal, int totalParcelas, DateTime dataLancamento, DateTime dataVencimento, Cartao cartao)
        {
            Descricao = descricao;
            Valor = valorTotal;
            DataLancamento = dataLancamento;
            DataVencimento = new DateTime(dataVencimento.Year, dataVencimento.Month, cartao.DiaVencimentoFatura);
            Cartao = cartao;
        }

        public int IdContaPagar { get; set; }
        public int ParcelaAtual { get; set; } = 1;
        public int TotalParcela { get; set; } = 1;
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool FlCancelado { get; set; }
        public int? IdCartao { get; set; }
        public virtual Cartao Cartao { get; set; }
    }
}
