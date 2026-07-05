using BackEnd.src.DTOs.Pessoa;
using BackEnd.src.Entities;
using BackEnd.src.Interfaces.Repositories;
using BackEnd.src.Interfaces.Services;
using BackEnd.src.Exceptions;
using Microsoft.AspNetCore.Http;

namespace BackEnd.src.Services;

/// <summary>
/// Implementa as regras de negócio relacionadas às pessoas.
/// </summary>
public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    /// <summary>
    /// Lista todas as pessoas cadastradas.
    /// </summary>
    public async Task<List<PessoaResponseDTO>> ListarAsync()
    {
        var pessoas = await _pessoaRepository.ListarAsync();

        return pessoas.Select(p => new PessoaResponseDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            Idade = p.Idade
        }).ToList();
    }

    /// <summary>
    /// Cria uma nova pessoa.
    /// </summary>
    public async Task<PessoaResponseDTO> CriarAsync(CriarPessoaDTO dto)
    {
        var pessoa = new Pessoa
        {
            Nome = dto.Nome,
            Idade = dto.Idade
        };

        await _pessoaRepository.CriarAsync(pessoa);

        await _pessoaRepository.SalvarAlteracoesAsync();

        return new PessoaResponseDTO
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            Idade = pessoa.Idade
        };
    }

    /// <summary>
    /// Exclui uma pessoa.
    /// </summary>
    public async Task ExcluirAsync(int id)
    {
        var pessoa = await _pessoaRepository.BuscarPorIdAsync(id);

        if (pessoa == null)

            throw new AppException("Pessoa não encontrada.", StatusCodes.Status404NotFound);

        await _pessoaRepository.ExcluirAsync(pessoa);

        await _pessoaRepository.SalvarAlteracoesAsync();
    }
}