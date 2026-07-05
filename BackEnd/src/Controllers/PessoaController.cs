using BackEnd.src.DTOs.Pessoa;
using BackEnd.src.Interfaces.Repositories;
using BackEnd.src.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.src.Controllers;

/// <summary>
/// Responsável pelo gerenciamento das pessoas.
/// </summary>
[ApiController]
[Route("api/pessoas")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    /// <summary>
    /// Lista todas as pessoas cadastradas.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<PessoaResponseDTO>>> Listar()
    {
        var pessoas = await _pessoaService.ListarAsync();

        return Ok(pessoas);
    }

    /// <summary>
    /// Cadastra uma nova pessoa.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<PessoaResponseDTO>> Criar(CriarPessoaDTO dto)
    {
        var pessoa = await _pessoaService.CriarAsync(dto);

        return CreatedAtAction(nameof(Listar), new { id = pessoa.Id }, pessoa);
    }

    /// <summary>
    /// Exclui uma pessoa.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await _pessoaService.ExcluirAsync(id);

        return NoContent();
    }
}