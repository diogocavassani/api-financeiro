using financeiro.aplicacao.App;
using financeiro.dominio.Repositorios;
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
    builder.Services.AddScoped<CartaoApp>();
    builder.Services.AddScoped<ContaPagarApp>();
    builder.Services.AddScoped<UnitOfWork>();
}