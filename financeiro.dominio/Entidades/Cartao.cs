using financeiro.dominio.Entidades.ContasPagar;

namespace financeiro.dominio.Entidades;

public class Cartao
{
    public Cartao()
    {
        ContasPagar = new List<ContaPagarCartao>();
    }


    /// <summary>
    /// Criar um cartão.
    /// </summary>
    /// <param name="nomeCartao"></param>
    /// <param name="vencimentoFatura"></param>
    public Cartao(string nomeCartao, int diaVencimentoFatura)
    {
        ContasPagar = new List<ContaPagarCartao>();

        NomeCartao = nomeCartao;
        DiaVencimentoFatura = diaVencimentoFatura;
        FlExcluido = false;
    }

    public int IdCartao { get; private set; }
    public string NomeCartao { get; private set; }
    public int DiaVencimentoFatura { get; private set; } = 1;
    public bool FlExcluido { get; private set; }
    public virtual List<ContaPagarCartao> ContasPagar { get; set; }

    public void Excluir()
    {
        FlExcluido = true;
    }

    public List<ContaPagarCartao> LancarContaPagar(string descricao, decimal valorParcela, int totalParcelas, DateTime dataLancamento)
    {
        var retorno = new List<ContaPagarCartao>();
        for (int parcela = 1; parcela <= totalParcelas; parcela++)
        {
            var contaPagar = new ContaPagarCartao(
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
