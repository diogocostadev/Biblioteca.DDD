using Biblioteca.DDD.Application.UseCases;
using Biblioteca.DDD.Domain.Repositories;
using Biblioteca.DDD.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<CadastrarLivroUseCase>();
builder.Services.AddScoped<ObterLivroUseCase>();

builder.Services.AddSingleton<DapperDbContext>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();