using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace financeiro.api.Models
{
    public class Cartao
    {
        protected Cartao()
        {
            ContasPagar = new Collection<ContaPagar>();
        }


        /// <summary>
        /// Criar um cartão.
        /// </summary>
        /// <param name="nomeCartao"></param>
        /// <param name="vencimentoFatura"></param>
        [SetsRequiredMembers]
        public Cartao(string nomeCartao, int diaVencimentoFatura)
        {
            ContasPagar = new Collection<ContaPagar>();

            NomeCartao = nomeCartao;
            DiaVencimentoFatura = diaVencimentoFatura;
            FlExcluido = false;
        }

        public int IdCartao { get; set; }
        public required string NomeCartao { get; set; }
        public int DiaVencimentoFatura { get; set; } = 1;
        public required bool FlExcluido { get; set; }
        public ICollection<ContaPagar> ContasPagar { get; set; }

        public void Excluir()
        {
            FlExcluido = true;
        }

        public void LancarContaPagar(string descricao, decimal valorTotal, int totalParcelas, DateTime dataLancamento, DateTime dataVencimento)
        {
            var valorParcela = Math.Round(valorTotal / totalParcelas, 2);
            for (int parcela = 0; parcela < totalParcelas; parcela++)
            {
                var contaPagar = new ContaPagar(descricao, valorParcela, totalParcelas, parcela + 1, dataLancamento, new DateTime(dataVencimento.Year, dataVencimento.AddMonths(parcela + 1).Month, DiaVencimentoFatura));

                ContasPagar.Add(contaPagar);
            }
        }
    }
}
