namespace financeiro.api.Models
{
    public class ContaPagar
    {
        public int IdContaPagar { get; set; }
        public int ParcelaAtual { get; set; }
        public int TotalParcela { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool FlCancelado { get; set; }
        public int IdCartao { get; set; }
        public virtual Cartao Cartao { get; set; }
    }
}
