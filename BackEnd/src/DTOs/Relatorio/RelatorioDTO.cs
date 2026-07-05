namespace BackEnd.src.DTOs.Relatorio;

/// <summary>
/// Representa o relatório geral do sistema.
/// </summary>
public class RelatorioDTO
{
    public List<PessoaRelatorioDTO> Pessoas { get; set; } = [];

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal SaldoGeral { get; set; }
}