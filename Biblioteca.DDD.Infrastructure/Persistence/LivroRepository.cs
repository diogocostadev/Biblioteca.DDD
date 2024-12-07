using Biblioteca.DDD.Domain.Entities;
using Biblioteca.DDD.Domain.Repositories;
using Dapper;

namespace Biblioteca.DDD.Infrastructure.Persistence;

public class LivroRepository : ILivroRepository
{
    private readonly DapperDbContext _dbContext;

    public LivroRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAsync(Livro livro)
    {
        var query = @"
                INSERT INTO Livros (Id, Titulo, Autor, Categoria, Disponivel)
                VALUES (@Id, @Titulo, @Autor, @Categoria, @Disponivel)";

        using var connection = _dbContext.CreateConnection();
        await connection.ExecuteAsync(query, livro);
    }

    public async Task<IEnumerable<Livro>> ObterTodosAsync()
    {
        var query = "SELECT * FROM Livros";

        using var connection = _dbContext.CreateConnection();
        return await connection.QueryAsync<Livro>(query);
    }

    public async Task<Livro> ObterPorIdAsync(Guid id)
    {
        var query = "SELECT * FROM Livros WHERE Id = @Id";

        using var connection = _dbContext.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Livro>(query, new { Id = id });
    }
}