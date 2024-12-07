using Biblioteca.DDD.Domain.Entities;

namespace Biblioteca.DDD.Domain.Services;

public class LivroService
{
    public bool ValidarLivro(Livro livro)
    {
        return !string.IsNullOrWhiteSpace(livro.Titulo) &&
               !string.IsNullOrWhiteSpace(livro.Autor) &&
               !string.IsNullOrWhiteSpace(livro.Categoria);
    }
}