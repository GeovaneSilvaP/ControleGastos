using BackEnd.src.Entities;

namespace BackEnd.src.Interfaces.Repositories;

/// <summary>
/// Contrato responsável pelas operações de acesso ao banco
/// relacionadas à entidade Pessoa.
/// </summary>
public interface IPessoaRepository
{
    Task<List<Pessoa>> ListarAsync();

    Task<Pessoa?> BuscarPorIdAsync(int id);

    Task CriarAsync(Pessoa pessoa);

    Task ExcluirAsync(Pessoa pessoa);

    Task SalvarAlteracoesAsync();
}