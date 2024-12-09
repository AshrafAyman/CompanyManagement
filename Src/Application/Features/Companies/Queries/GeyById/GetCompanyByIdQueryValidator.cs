using FluentValidation;

namespace Application.Features.Companies.Queries.GeyById;

public class GetCompanyByIdQueryValidator : AbstractValidator<GetCompanyByIdQuery>
{
    public GetCompanyByIdQueryValidator()
    {
        RuleFor(e => e.CompanyId)
            .NotEmpty()
            .WithMessage("Company Id is required");
    }
}