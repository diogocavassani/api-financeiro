using financeiro.aplicacao.App;
using financeiro.dominio.Interfaces.App;
using financeiro.dominio.Interfaces.Repositorios;
using financeiro.dominioNucleoCompartilhado;
using financeiro.dominioNucleoCompartilhado.Eventos;
using financeiro.dominioNucleoCompartilhado.EventosHandlers;
using financeiro.infra.Contexto;
using financeiro.infra.Repositorio;
using financeiro.infra.Transacao;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();


void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<DataContext>(
        options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    builder.Services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();
    builder.Services.AddScoped<IContaPagarRepositorio, ContaPagarRepositorio>();
    builder.Services.AddScoped<ICartaoApp, CartaoApp>();
    builder.Services.AddScoped<IContaPagarApp, ContaPagarApp>();
    builder.Services.AddScoped<UnitOfWork>();
    builder.Services.AddScoped<IHandle<NotificacaoEvento>, NotificacaoEventoHandler>();
}