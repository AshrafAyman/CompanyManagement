using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Features.Companies.Queries.GetAll.DTOs;

namespace Application.Features.Companies.Queries.GetAll;

public class GetAllCompaniesQuery : PaginationDTO, IRequest<CompanyOutputDTO>
{
    public string SortBy { get; set; }
}

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, CompanyOutputDTO>
{
    private readonly IAppDbContext _context;

    public GetAllCompaniesQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyOutputDTO> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Companies.Include(c => c.Branch).AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SortBy))
            query = request.SortBy.ToLower() switch
            {
                "name" => query.OrderBy(c => c.Name),
                "create date" => query.OrderBy(c => c.CreatedAt),
                _ => query
            };

        var count = await query.CountAsync(cancellationToken);

        var companies =  await query
            .AsNoTracking()
            .Skip((request.Current_page - 1) * request.Page_size)
            .Take(request.Page_size)
            .Select(e=> new CompanyDTO(e.Id,e.Name,e.Email,e.Branch.Address))
            .ToListAsync(cancellationToken);

        return new CompanyOutputDTO(companies,count,request.Page_size,request.Current_page);
    }
}