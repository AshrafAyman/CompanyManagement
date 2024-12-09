using FluentValidation;

namespace Application.Features.Branches.Commands.Update;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(e => e.BranchAddress)
            .NotEmpty()
            .WithMessage("Branch address is required");

        RuleFor(e => e.Id)
            .NotEmpty()
            .WithMessage("Branch Id is required");
    }
}