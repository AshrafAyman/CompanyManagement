using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Branches.Queries.GetAll.DTOs;
using Application.Features.Companies.Queries.GetAll.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Branches.Queries.GetById;

public class GetBranchByIdQuery : IRequest<BranchDTO>
{
    public Guid Id { get; set; }
}

public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDTO>
{
    private readonly IAppDbContext _context;

    public GetBranchByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<BranchDTO> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
    {
        var branch = await _context.Branches
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (branch == null) throw new NotFoundException("Branch not found");

        return new BranchDTO(branch.Id, branch.Address);
    }
}