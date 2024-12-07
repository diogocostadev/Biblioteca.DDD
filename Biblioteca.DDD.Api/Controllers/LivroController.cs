using Biblioteca.DDD.Application.DTOs;
using Biblioteca.DDD.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.DDD.Controllers;

[ApiController]
[Route("api/livros")]
public class LivroController : ControllerBase
{
    private readonly CadastrarLivroUseCase _cadastrarLivroUseCase;
    private readonly ObterLivroUseCase _obterLivroUseCase;

    public LivroController(CadastrarLivroUseCase cadastrarLivroUseCase, ObterLivroUseCase obterLivroUseCase)
    {
        _cadastrarLivroUseCase = cadastrarLivroUseCase;
        _obterLivroUseCase = obterLivroUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarLivro([FromBody] LivroDto dto)
    {
        await _cadastrarLivroUseCase.Execute(dto.Titulo, dto.Autor, dto.Categoria);
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterLivro(Guid id)
    {
        var livroDto = await _obterLivroUseCase.Execute(id);

        if (livroDto == null)
        {
            return NotFound(new { Mensagem = "Livro não encontrado." });
        }

        return Ok(livroDto);
    }

}