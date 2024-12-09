using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IAppDbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}