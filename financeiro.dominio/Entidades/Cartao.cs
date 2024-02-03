using financeiro.dominio.ViewModels;
using System.Collections.ObjectModel;

namespace financeiro.dominio.Entidades;

public class Cartao
{
    protected Cartao()
    {
        ContasPagar = new List<ContaPagar>();
    }


    /// <summary>
    /// Criar um cartão.
    /// </summary>
    /// <param name="nomeCartao"></param>
    /// <param name="vencimentoFatura"></param>
    public Cartao(string nomeCartao, int diaVencimentoFatura)
    {
        ContasPagar = new List<ContaPagar>();

        NomeCartao = nomeCartao;
        DiaVencimentoFatura = diaVencimentoFatura;
        FlExcluido = false;
    }

    public int IdCartao { get; private set; }
    public string NomeCartao { get; private set; }
    public int DiaVencimentoFatura { get; private set; } = 1;
    public bool FlExcluido { get; private set; }
    public virtual List<ContaPagar> ContasPagar { get; set; }

    public void Excluir()
    {
        FlExcluido = true;
    }

    public List<ContaPagar> LancarContaPagar(string descricao, decimal valorParcela, int totalParcelas, DateTime dataLancamento)
    {
        var retorno = new List<ContaPagar>();
        for (int parcela = 1; parcela <= totalParcelas; parcela++)
        {
            var contaPagar = new ContaPagar(
                descricao,
                valorParcela,
                totalParcelas,
                parcela,
                dataLancamento,
                new DateTime(dataLancamento.AddMonths(parcela).Year, dataLancamento.AddMonths(parcela).Month, DiaVencimentoFatura),
                this);
            retorno.Add(contaPagar);
        }
        ContasPagar.AddRange(retorno);
        return retorno;
    }
}
