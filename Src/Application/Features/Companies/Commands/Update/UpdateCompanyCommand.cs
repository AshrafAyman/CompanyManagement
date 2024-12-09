using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string BranchAddress { get; set; }
}

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
{
    private readonly IAppDbContext _context;

    public UpdateCompanyCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.Include(c => c.Branch).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (company == null) throw new NotFoundException("Company not found");

        company.Name = request.Name ?? company.Name;
        company.Email = request.Email ?? company.Email;

        if (request.BranchAddress != null && company.Branch != null)
        {
            company.Branch.Address = request.BranchAddress;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}