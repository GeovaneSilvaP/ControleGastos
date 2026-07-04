namespace BackEnd.src.DTOs.Pessoa;

/// <summary>
/// Dados necessários para cadastrar uma nova pessoa.
/// </summary>
public class CriarPessoaDTO
{
    /// <summary>
    /// Nome da pessoa.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Idade da pessoa.
    /// </summary>
    public int Idade { get; set; }
}