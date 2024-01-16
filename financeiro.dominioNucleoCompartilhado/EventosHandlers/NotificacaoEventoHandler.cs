using financeiro.dominioNucleoCompartilhado.Eventos;
using MediatR;
using System.Collections.ObjectModel;

namespace financeiro.dominioNucleoCompartilhado.EventosHandlers
{
    public class NotificacaoEventoHandler : IHandle<NotificacaoEvento>
    {
        public ICollection<NotificacaoEvento> Notificacoes { get; }

        public NotificacaoEventoHandler()
        {
            Notificacoes = new Collection<NotificacaoEvento>();
        }

        public Task Handle(NotificacaoEvento notificacao)
        {
            Notificacoes.Add(notificacao);
            return Task.CompletedTask;
        }

        public bool ExisteNotificacoes()
        {
            return Notificacoes.Count > 0;
        }

        public ICollection<NotificacaoEvento> ObterNotificacoes()
        {
            return Notificacoes;
        }

    }
}
