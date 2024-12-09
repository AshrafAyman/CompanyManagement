using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Common;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace  MicrblogApp.Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser>, IAppDbContext
{
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _currentUserService;

    public AppDbContext()
    {
     
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
     
    }

    public AppDbContext(DbContextOptions options , ICurrentUserService currentUserService,IDateTime dateTime ) : base(options)
    {
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }


    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.DetectChanges();
        BeforeSaving();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void BeforeSaving()
    {
        ChangeTracker.Entries<IAuditableEntity>().ToList().ForEach(entry =>
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy =
                    _currentUserService?.UserId != null ? _currentUserService.UserId : Guid.NewGuid().ToString();
                entry.Entity.CreatedAt = _dateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedBy =
                    _currentUserService?.UserId != null ? _currentUserService.UserId : string.Empty;
                entry.Entity.LastModifiedOn = _dateTime?.Now ?? DateTime.Now;
            }
        });
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

