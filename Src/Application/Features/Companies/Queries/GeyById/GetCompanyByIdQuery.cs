using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Companies.Queries.GetAll.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Companies.Queries.GeyById;

public class GetCompanyByIdQuery : IRequest<CompanyDTO>
{
    public Guid CompanyId { get; set; }
}

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDTO>
{
    private readonly IAppDbContext _context;

    public GetCompanyByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies
            .Include(c => c.Branch)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.CompanyId,cancellationToken);

        if (company == null) throw new NotFoundException("Company not found");
        return new CompanyDTO(company.Id, company.Name, company.Email, company.Branch.Address);
    }
}