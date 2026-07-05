namespace BackEnd.src.DTOs.Relatorio;

/// <summary>
/// Resumo financeiro de uma pessoa.
/// </summary>
public class PessoaRelatorioDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal Saldo { get; set; }
}