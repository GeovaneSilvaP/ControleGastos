using BackEnd.src.DTOs.Relatorio;
using BackEnd.src.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.src.Controllers;


/// <summary>
/// Responsável pela consulta dos totais financeiros.
/// </summary>
[ApiController]
[Route("api/relatorio")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;

    public RelatorioController(IRelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }

    /// <summary>
    /// Retorna o relatório financeiro.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<RelatorioDTO>> ObterRelatorio()
    {
        var relatorio = await _relatorioService.ObterRelatorioAsync();

        return Ok(relatorio);
    }
}