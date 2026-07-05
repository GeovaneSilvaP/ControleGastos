using BackEnd.src.DTOs.Transacao;
using BackEnd.src.Entities;
using BackEnd.src.Entities.Enums;
using BackEnd.src.Interfaces.Repositories;
using BackEnd.src.Interfaces.Services;
using BackEnd.src.Exceptions;
using Microsoft.AspNetCore.Http;

namespace BackEnd.src.Services;

/// <summary>
/// Implementa as regras de negócio relacionadas às transações.
/// </summary>
public class TransacaoService : ITransacaoService
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IPessoaRepository _pessoaRepository;

    public TransacaoService(
        ITransacaoRepository transacaoRepository,
        IPessoaRepository pessoaRepository
    )
    {
        _transacaoRepository = transacaoRepository;
        _pessoaRepository = pessoaRepository;
    }

    /// <summary>
    /// Lista todas as transações cadastradas.
    /// </summary>
    public async Task<List<TransacaoResponseDTO>> ListarAsync()
    {
        var transacoes = await _transacaoRepository.ListarAsync();

        return transacoes.Select(t => new TransacaoResponseDTO
        {
            Id = t.Id,
            Descricao = t.Descricao,
            Valor = t.Valor,
            Tipo = t.Tipo,
            PessoaId = t.PessoaId
        }).ToList();
    }

    /// <summary>
    /// Cria uma nova transação.
    /// </summary>
    public async Task<TransacaoResponseDTO> CriarAsync(CriarTransacaoDTO dTO)
    {
        // 1 - Verifica se a pessoa existe
        var pessoa = await _pessoaRepository.BuscarPorIdAsync(dTO.PessoaId);

        if (pessoa == null)
        {
            throw new AppException("Pessoa não encontrada.", StatusCodes.Status404NotFound);
        }

        // 2 - Verifica se é menor de idade
        if (pessoa.Idade < 18 && dTO.Tipo == TipoTransacao.Receita)
        {
            throw new AppException("Menores de idade só podem cadastrar despesas.", StatusCodes.Status400BadRequest);
        }

        // 3 - Impede um valor negativo ou zero
        if (dTO.Valor <= 0)
        {
            throw new AppException("O valor da transação deve ser maior que zero.", StatusCodes.Status400BadRequest);
        }

        // 4 - Cria a entidade
        var transacao = new Transacao
        {
            Descricao = dTO.Descricao,
            Valor = dTO.Valor,
            Tipo = dTO.Tipo,
            PessoaId = dTO.PessoaId
        };

        // 5 - Salva
        await _transacaoRepository.CriarAsync(transacao);

        await _transacaoRepository.SalvarAlteracoesAsync();

        // 6 - Retorna o DTO
        return new TransacaoResponseDTO
        {
            Id = transacao.Id,
            Descricao = transacao.Descricao,
            Valor = transacao.Valor,
            Tipo = transacao.Tipo,
            PessoaId = transacao.PessoaId
        };
    }
}