using BackEnd.src.DTOs.Transacao;
using BackEnd.src.Interfaces.Repositories;
using BackEnd.src.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.src.Controllers;

/// <summary>
/// Responsável pelo gerenciamento das transações.
/// </summary>
[ApiController]
[Route("api/transacoes")]
public class TransacaoController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    /// <summary>
    /// Lista todas as transações.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<TransacaoResponseDTO>>> Listar()
    {
        var transacoes = await _transacaoService.ListarAsync();

        return Ok(transacoes);
    }

    /// <summary>
    /// Cadastra uma nova transação.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TransacaoResponseDTO>> Criar(CriarTransacaoDTO dto)
    {
        var transacao = await _transacaoService.CriarAsync(dto);

        return Created(string.Empty, transacao);
    }
}