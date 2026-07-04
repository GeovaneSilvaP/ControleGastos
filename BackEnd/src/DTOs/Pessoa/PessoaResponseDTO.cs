namespace BackEnd.src.DTOs.Pessoa;

/// <summary>
/// Dados retornados pela API após consultar uma pessoa.
/// </summary>
public class PessoaResponseDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public int Idade { get; set; }
}