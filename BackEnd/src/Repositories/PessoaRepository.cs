using BackEnd.src.Data;
using BackEnd.src.Entities;
using BackEnd.src.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.src.Repositories;

/// <summary>
/// Responsável pelas operações de acesso ao banco
/// relacionadas às pessoas.
/// </summary>
public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// O DbContext é injetado pelo sistema de Injeção de Dependência.
    /// </summary>
    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retorna todas as pessoas cadastradas.
    /// </summary>
    public async Task<List<Pessoa>> ListarAsync()
    {
        return await _context.Pessoas.ToListAsync();
    }

    /// <summary>
    /// Busca uma pessoa pelo Id.
    /// </summary>
    public async Task<Pessoa?> BuscarPorIdAsync(int id)
    {
        return await _context.Pessoas
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Adiciona uma nova pessoa ao contexto.
    /// Ainda não salva no banco.
    /// </summary>
    public async Task CriarAsync(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
    }

    /// <summary>
    /// Remove uma pessoa do contexto.
    /// </summary>
    public Task ExcluirAsync(Pessoa pessoa)
    {
        _context.Pessoas.Remove(pessoa);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Persiste todas as alterações no banco.
    /// </summary>
    public async Task SalvarAlteracoesAsync()
    {
        await _context.SaveChangesAsync();
    }
}