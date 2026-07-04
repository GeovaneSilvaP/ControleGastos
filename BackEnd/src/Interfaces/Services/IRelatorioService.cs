using BackEnd.src.DTOs.Pessoa;

namespace BackEnd.src.Interfaces.Services;

/// <summary>
/// Contrato responsável pela geração do relatório
/// financeiro.
/// </summary>
public interface IRelatorioService
{
    Task<List<PessoaResumoDTO>> ObterResumoAsync();
}