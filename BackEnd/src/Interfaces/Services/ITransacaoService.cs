using BackEnd.src.DTOs.Transacao;

namespace BackEnd.src.Interfaces.Repositories;

public interface ITransacaoService
{

    Task<List<TransacaoResponseDTO>> ListarAsync();

    Task<TransacaoResponseDTO> CriarAsync(CriarTransacaoDTO dto);
}