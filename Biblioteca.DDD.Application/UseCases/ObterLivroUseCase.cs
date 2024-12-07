using Biblioteca.DDD.Application.DTOs;
using Biblioteca.DDD.Domain.Repositories;

namespace Biblioteca.DDD.Application.UseCases;

public class ObterLivroUseCase
{
    private readonly ILivroRepository _repository;

    public ObterLivroUseCase(ILivroRepository repository)
    {
        _repository = repository;
    }

    public async Task<LivroDto> Execute(Guid id)
    {
        var livro = await _repository.ObterPorIdAsync(id);

        if (livro == null) return null;

        // Converte o livro para um DTO
        return new LivroDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Categoria = livro.Categoria,
            Disponivel = livro.Disponivel
        };
    }
}