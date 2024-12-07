using Biblioteca.DDD.Domain.Entities;
using Biblioteca.DDD.Domain.Repositories;

namespace Biblioteca.DDD.Application.UseCases;

public class CadastrarLivroUseCase
{
    private readonly ILivroRepository _repository;

    public CadastrarLivroUseCase(ILivroRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(string titulo, string autor, string categoria)
    {
        var livro = new Livro(titulo, autor, categoria);
        await _repository.AdicionarAsync(livro);
    }
}