using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Branches.Commands.Update;

public class UpdateBranchCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string BranchAddress { get; set; }
}

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
{
    private readonly IAppDbContext _context;

    public UpdateBranchCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _context.Branches.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (branch == null) throw new NotFoundException("Branch not found");

        branch.Address = request.BranchAddress ?? branch.Address;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}