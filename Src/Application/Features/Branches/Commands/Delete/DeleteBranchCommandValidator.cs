using FluentValidation;

namespace Application.Features.Branches.Commands.Delete;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty()
            .WithMessage("Branch Id is required");
    }
}