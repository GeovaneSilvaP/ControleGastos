using BackEnd.src.DTOs.Relatorio;
using BackEnd.src.Entities.Enums;
using BackEnd.src.Interfaces.Repositories;
using BackEnd.src.Interfaces.Services;

namespace BackEnd.src.Services;

/// <summary>
/// Responsável por gerar o relatório financeiro.
/// </summary>
public class RelatorioService : IRelatorioService
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ITransacaoRepository _transacaoRepository;

    public RelatorioService(
        IPessoaRepository pessoaRepository,
        ITransacaoRepository transacaoRepository)
    {
        _pessoaRepository = pessoaRepository;
        _transacaoRepository = transacaoRepository;
    }

    public async Task<RelatorioDTO> ObterRelatorioAsync()
    {
        var pessoas = await _pessoaRepository.ListarAsync();

        var transacoes = await _transacaoRepository.ListarAsync();

        var relatorio = new RelatorioDTO();

        foreach (var pessoa in pessoas)
        {
            var transacoesPessoa = transacoes
                .Where(t => t.PessoaId == pessoa.Id);

            var receitas = transacoesPessoa
                .Where(t => t.Tipo == TipoTransacao.Receita)
                .Sum(t => t.Valor);

            var despesas = transacoesPessoa
                .Where(t => t.Tipo == TipoTransacao.Despesa)
                .Sum(t => t.Valor);

            relatorio.Pessoas.Add(new PessoaRelatorioDTO
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                TotalReceitas = receitas,
                TotalDespesas = despesas,
                Saldo = receitas - despesas
            });
        }

        relatorio.TotalReceitas = relatorio.Pessoas.Sum(p => p.TotalReceitas);

        relatorio.TotalDespesas = relatorio.Pessoas.Sum(p => p.TotalDespesas);

        relatorio.SaldoGeral = relatorio.TotalReceitas - relatorio.TotalDespesas;

        return relatorio;
    }
}