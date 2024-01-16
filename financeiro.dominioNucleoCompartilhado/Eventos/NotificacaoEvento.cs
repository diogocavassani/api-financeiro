using MediatR;

namespace financeiro.dominioNucleoCompartilhado.Eventos
{
    public class NotificacaoEvento : INotification
    {
        public NotificacaoEvento(string chave, string mensagem)
        {
            Chave = chave;
            Mensagem = mensagem;
        }

        public string Chave { get; }
        public string Mensagem { get; }
    }
}
