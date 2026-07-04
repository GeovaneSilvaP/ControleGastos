using BackEnd.src.Entities.Enums;

namespace BackEnd.src.Entities;

/// <summary>
/// Representa uma movimentação financeira.
/// </summary>
public class Transacao
{
    /// <summary>
    /// Identificador da transação.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Descrição da movimentação.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Valor da transação.
    /// </summary>
    public decimal Valor { get; set; }

    /// <summary>
    /// Tipo da transação (Receita ou Despesa).
    /// </summary>
    public TipoTransacao Tipo { get; set; }

    /// <summary>
    /// Chave estrangeira da pessoa.
    /// </summary>
    public int PessoaId { get; set; }

    /// <summary>
    /// Pessoa relacionada à transação.
    /// </summary>
    public Pessoa? Pessoa { get; set; }
}