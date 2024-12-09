using FluentValidation;
using System.Text.RegularExpressions;
using static Common.Constants;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    private Regex ValidEmailRegex { get; }
    public CreateCompanyCommandValidator()
    {
        ValidEmailRegex = CreateValidEmailRegex();

        RuleFor(e => e.Email)
            .Must(IsValidEmail)
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(50)
            .WithMessage("Company name must not exceed 50 characters.");

        RuleFor(x => x.BranchAddress)
            .NotEmpty()
            .WithMessage("Branch address is required.");
    }

    private Regex CreateValidEmailRegex()
        => new(ConstantRegex.EmailRegexPattern, RegexOptions.IgnoreCase);

    private bool IsValidEmail(string email)
        => ValidEmailRegex.IsMatch(email);
}