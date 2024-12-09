using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Branches.Commands.Delete;

public class DeleteBranchCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Unit>
{
    private readonly IAppDbContext _context;

    public DeleteBranchCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _context.Branches
            .Include(e => e.Company)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (branch == null) throw new NotFoundException("Branch not found");

        if (branch.Company != null || !branch.Company.IsDeleted) throw new BadRequestException("Can't delete this branch because there is a company linked to it");

        branch.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}