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
        public Cartao(string nomeCartao, int diaVencimentoFatura)
        {
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
    }
}
