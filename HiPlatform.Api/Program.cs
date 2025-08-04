using HiPlatform.Api.Dados;
using HiPlatform.Api.Servico;
using HiPlatform.Api.Servico.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AplicacaoDbContexto>();
builder.Services.AddScoped<IDataServico, DataServico>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.AtualizarBancoDeDadosAsync(app.Environment);

await app.RunAsync();