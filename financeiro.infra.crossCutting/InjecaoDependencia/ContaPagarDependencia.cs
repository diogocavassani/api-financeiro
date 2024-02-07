using financeiro.aplicacao.App;
using financeiro.dominio.Interfaces.App;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace financeiro.infra.crossCutting.InjecaoDependencia
{
    public static class ContaPagarDependencia
    {
        public static IServiceCollection AddContaPagarDependencia(this IServiceCollection serviceCollections)
        {
            serviceCollections.AddScoped<IContaPagarApp, ContaPagarApp>();

            serviceCollections.AddScoped<IContaPagarRepositorio, ContaPagarRepositorio>();

            return serviceCollections;
        }
    }
}
