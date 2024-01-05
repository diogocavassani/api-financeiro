using System.Collections.ObjectModel;

namespace financeiro.dominio.Entidade;

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
    public Cartao(string nomeCartao, int diaVencimentoFatura)
    {
        ContasPagar = new Collection<ContaPagar>();

        NomeCartao = nomeCartao;
        DiaVencimentoFatura = diaVencimentoFatura;
        FlExcluido = false;
    }

    public int IdCartao { get; private set; }
    public string NomeCartao { get; private set; }
    public int DiaVencimentoFatura { get; private set; } = 1;
    public bool FlExcluido { get; private set; }
    public virtual ICollection<ContaPagar> ContasPagar { get; set; }

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
