using financeiro.aplicacao.App;
using financeiro.dominio.Interfaces.App;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.infra.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace financeiro.infra.crossCutting.InjecaoDependencia
{
    public static class CartaoDependencia
    {
        public static IServiceCollection AddCartaoDependencia(this IServiceCollection serviceCollections)
        {
            serviceCollections.AddScoped<ICartaoApp, CartaoApp>();

            serviceCollections.AddScoped<ICartaoRepositorio, CartaoRepositorio>();

            return serviceCollections;
        }
    }
}
