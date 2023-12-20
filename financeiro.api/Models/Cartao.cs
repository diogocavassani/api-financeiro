using System.Diagnostics.CodeAnalysis;

namespace financeiro.api.Models
{
    public class Cartao
    {
        protected Cartao()
        {
            
        }


        /// <summary>
        /// Criar um cartão.
        /// </summary>
        /// <param name="nomeCartao"></param>
        /// <param name="vencimentoFatura"></param>
        [SetsRequiredMembers]
        public Cartao(string nomeCartao, DateTime? vencimentoFatura)
        {
            NomeCartao = nomeCartao;
            DataVencimentoFatura = vencimentoFatura;
            FlExcluido = false;
        }

        public int IdCartao { get; set; }
        public required string NomeCartao { get; set; }
        public DateTime? DataVencimentoFatura { get; set; }
        public required bool FlExcluido { get; set; }

        public void Excluir()
        {
            FlExcluido = true;
        }
    }
}
