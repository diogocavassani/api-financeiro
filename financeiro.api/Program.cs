using financeiro.infra.crossCutting.InjecaoDependencia;

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

    builder.Services.AddComumDependencia(builder.Configuration);
    builder.Services.AddCartaoDependencia();
    builder.Services.AddContaPagarDependencia();
}