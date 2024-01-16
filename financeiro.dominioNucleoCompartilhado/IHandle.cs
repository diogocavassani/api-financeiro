using financeiro.dominioNucleoCompartilhado.Eventos;

namespace financeiro.dominioNucleoCompartilhado
{
    public interface IHandle<T> where T : NotificacaoEvento 
    {
        Task Handle(T evento);
        bool ExisteNotificacoes();
        ICollection<NotificacaoEvento> ObterNotificacoes();

    }
}
