using FluentValidation;

namespace Application.Features.Branches.Queries.GetById;

public class GetBranchByIdQueryValidator : AbstractValidator<GetBranchByIdQuery>
{
    public GetBranchByIdQueryValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty()
            .WithMessage("Branch Id is required");
    }
}