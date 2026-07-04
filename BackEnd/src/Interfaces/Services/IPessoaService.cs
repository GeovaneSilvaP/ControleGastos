using BackEnd.src.DTOs.Pessoa;

namespace BackEnd.src.Interfaces.Repositories;

/// <summary>
/// Contrato responsável pelas regras de negócio
/// relacionadas às pessoas.
/// </summary>
public interface IPessoaService
{
    Task<List<PessoaResponseDTO>> ListarAsync();

    Task<PessoaResponseDTO> CriarAsync(CriarPessoaDTO dTO);

    Task ExcluirAsync(int id);
}