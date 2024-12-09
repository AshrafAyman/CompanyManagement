using MediatR;
using System.ComponentModel.DataAnnotations;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string BranchAddress { get; set; }
}

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Unit>
{
    private readonly IAppDbContext _context;

    public CreateCompanyCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Name = request.Name,
            Email = request.Email,
            Branch = new Branch { Address = request.BranchAddress }
        };

        await _context.Companies.AddAsync(company,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}