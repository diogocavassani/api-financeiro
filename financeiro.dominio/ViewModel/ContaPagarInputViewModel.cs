namespace financeiro.dominio.ViewModel
{
    public class ContaPagarInputViewModel
    {
        public required string Descricao { get; set; }
        public int TotalParcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public int? IdCartao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
