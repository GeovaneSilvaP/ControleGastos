using BackEnd.src.DTOs.Relatorio;

namespace BackEnd.src.Interfaces.Services;

/// <summary>
/// Contrato responsável pela geração do relatório
/// financeiro.
/// </summary>
public interface IRelatorioService
{
    Task<RelatorioDTO> ObterRelatorioAsync();
}