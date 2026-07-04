using BackEnd.src.Entities.Enums;

namespace BackEnd.src.DTOs.Transacao;

/// <summary>
/// Dados retornados ao consultar transações.
/// </summary>
public class TransacaoResponseDTO
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public int PessoaId { get; set; }
}