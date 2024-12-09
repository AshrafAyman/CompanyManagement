using FluentValidation;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(e => e.CompanyId)
            .NotNull()
            .NotEmpty()
            .WithMessage("Company Id is required");
    }
}