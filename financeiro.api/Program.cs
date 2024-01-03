using financeiro.api.Data;
using financeiro.api.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
    builder.Services.AddScoped<CartaoRepositorio>();
    builder.Services.AddScoped<ContaPagarRepositorio>();
}