using Biblioteca.DDD.Domain.Entities;

namespace Biblioteca.DDD.Domain.Repositories;


public interface ILivroRepository
{
    Task AdicionarAsync(Livro livro);
    Task<IEnumerable<Livro>> ObterTodosAsync();
    Task<Livro> ObterPorIdAsync(Guid id);
}