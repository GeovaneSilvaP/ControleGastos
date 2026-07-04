using BackEnd.src.Entities;

namespace BackEnd.src.Interfaces.Repositories;

/// <summary>
/// Contrato responsável pelas operações de acesso
/// às transações.
/// </summary>
public interface ITransacaoRepository
{
    Task<List<Transacao>> ListarAsync();
    Task<List<Transacao>> ListarPorPessoaAsync(int pessoaId);
    Task CriarAsync(Transacao transacao);
    Task SalvarAlteracoesAsync();
}