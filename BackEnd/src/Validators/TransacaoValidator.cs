using BackEnd.src.DTOs.Transacao;
using BackEnd.src.Entities.Enums;
using FluentValidation;

namespace BackEnd.src.Validators;

/// <summary>
/// Valida os dados necessários para criar uma transação.
/// </summary>
public class TransacaoValidator : AbstractValidator<CriarTransacaoDTO>
{
    public TransacaoValidator()
    {
        RuleFor(x => x.Descricao)
        .NotEmpty()
        .WithMessage("A descrição é obrigatória.")
        .MaximumLength(255)
        .WithMessage("A descrição deve possuir no máximo 255 caracteres.");

        RuleFor(x => x.Valor)
        .GreaterThan(0)
        .WithMessage("O valor deve ser maior que zero.");

        RuleFor(x => x.PessoaId)
        .GreaterThan(0)
        .WithMessage("Pessoa inválida.");

        RuleFor(x => x.Tipo)
        .Must(tipo =>
        tipo == TipoTransacao.Receita ||
        tipo == TipoTransacao.Despesa)
        .WithMessage("Tipo de transação inválido.");
    }
}