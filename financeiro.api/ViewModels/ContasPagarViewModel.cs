namespace financeiro.api.ViewModels
{
    public class ContasPagarViewModel
    {
        public required string Descricao { get; set; }
        public int TotalParcelas { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

    }
}
