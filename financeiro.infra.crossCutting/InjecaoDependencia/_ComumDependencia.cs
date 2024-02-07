using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.dominioNucleoCompartilhado.EventosHandlers;
using financeiro.infra.Contexto;
using financeiro.infra.Transacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace financeiro.infra.crossCutting.InjecaoDependencia
{
    public static class _ComumDependencia
    {
        public static IServiceCollection AddComumDependencia(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DataContext>(
        options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));


            serviceCollection.AddScoped<UnitOfWork>();
            serviceCollection.AddScoped<IHandle<NotificacaoEvento>, NotificacaoEventoHandler>();

            return serviceCollection;
        }
    }
}
