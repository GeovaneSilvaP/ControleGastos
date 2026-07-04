using BackEnd.src.Entities.Enums;

namespace BackEnd.src.DTOs.Transacao;


/// <summary>
/// Dados necessários para cadastrar uma transação.
/// </summary> 
public class CriarTransacaoDTO
{
    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public int PessoaId { get; set; }
}