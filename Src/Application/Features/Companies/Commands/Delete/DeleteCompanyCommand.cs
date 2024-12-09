using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyCommand : IRequest<Unit>
{
    public Guid CompanyId { get; set; }
}

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand,Unit>
{
    private readonly IAppDbContext _context;

    public DeleteCompanyCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.Include(c => c.Branch).FirstOrDefaultAsync(c => c.Id == request.CompanyId,cancellationToken);
        if (company == null) throw new NotFoundException("Company not found");

        company.IsDeleted = true;
        if (company.Branch != null)
        {
            company.Branch.IsDeleted = true;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}