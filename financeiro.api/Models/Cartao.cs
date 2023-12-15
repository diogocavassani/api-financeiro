using System.Diagnostics.CodeAnalysis;

namespace financeiro.api.Models
{
    public class Cartao
    {
        protected Cartao()
        {
            
        }
        [SetsRequiredMembers]
        public Cartao(string nomeCartao, DateTime? vencimentoFatura)
        {
            NomeCartao = nomeCartao;
            DataVencimentoFatura = vencimentoFatura;
        }

        public int IdCartao { get; set; }
        public required string NomeCartao { get; set; }
        public DateTime? DataVencimentoFatura { get; set; }

    }
}
