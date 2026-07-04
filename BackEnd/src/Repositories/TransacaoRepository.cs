using BackEnd.src.Data;
using BackEnd.src.Entities;
using BackEnd.src.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.src.Repositories;

/// <summary>
/// Responsável pelo acesso ao banco das transações.
/// </summary>
public class TransacaoRepository : ITransacaoRepository
{
    private readonly AppDbContext _context;

    public TransacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transacao>> ListarAsync()
    {
        return await _context.Transacoes
            .Include(t => t.Pessoa)
            .ToListAsync();
    }

    public async Task<List<Transacao>> ListarPorPessoaAsync(int pessoaId)
    {
        return await _context.Transacoes
            .Where(t => t.PessoaId == pessoaId)
            .Include(t => t.Pessoa)
            .ToListAsync();
    }

    public async Task CriarAsync(Transacao transacao)
    {
        await _context.Transacoes.AddAsync(transacao);
    }

    public async Task SalvarAlteracoesAsync()
    {
        await _context.SaveChangesAsync();
    }
}