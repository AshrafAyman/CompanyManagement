using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Features.Branches.Queries.GetAll.DTOs;
using Application.Features.Companies.Queries.GetAll.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Branches.Queries.GetAll;

public class GetAllBranchesQuery : PaginationDTO,IRequest<BranchOutputDTO>
{
    public string SortBy { get; set; }
}

public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, BranchOutputDTO>
{
    private readonly IAppDbContext _context;

    public GetAllBranchesQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<BranchOutputDTO> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Branches.Include(c => c.Company).AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SortBy))
            query = request.SortBy.ToLower() switch
            {
                "address" => query.OrderBy(c => c.Address),
                "company name" => query.OrderBy(c => c.CreatedAt),
                "create date" => query.OrderBy(c => c.CreatedAt),
                _ => query
            };

        var count = await query.CountAsync(cancellationToken);

        var branches = await query
            .AsNoTracking()
            .Skip((request.Current_page - 1) * request.Page_size)
            .Take(request.Page_size)
            .Select(e => new BranchDTO(e.Id,e.Address))
            .ToListAsync(cancellationToken);

        return new BranchOutputDTO(branches, count, request.Page_size, request.Current_page);
    }
}