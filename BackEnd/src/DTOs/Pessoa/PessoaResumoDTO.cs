namespace BackEnd.src.DTOs.Pessoa;

/// <summary>
/// Representa o resumo financeiro de uma pessoa.
/// </summary>
public class PessoaResumoDTO
{
    public string Nome { get; set; } = string.Empty;

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal Saldo { get; set; }
}