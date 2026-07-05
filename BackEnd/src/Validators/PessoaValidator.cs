using BackEnd.src.DTOs.Pessoa;
using FluentValidation;

namespace BackEnd.src.Validators;

/// <summary>
/// Valida os dados necessários para criar uma pessoa.
/// </summary>
public class PessoaValidator : AbstractValidator<CriarPessoaDTO>
{
    public PessoaValidator()
    {
        RuleFor(x => x.Nome)
        .NotEmpty()
        .WithMessage("O nome é obrigatório.")
        .MinimumLength(3)
        .WithMessage("O nome deve possuir no mínimo 3 caracteres.")
        .MaximumLength(150)
        .WithMessage("O nome deve possuir no máximo 150 caracteres.");

        RuleFor(x => x.Idade)
        .InclusiveBetween(0, 120)
        .WithMessage("A idade deve estar entre 0 e 120 anos.");
    }
}