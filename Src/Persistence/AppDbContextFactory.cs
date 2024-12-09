using Application.Common.Interfaces;
using Common;
using Microsoft.EntityFrameworkCore;

namespace MicrblogApp.Persistence;

public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
{
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _currentUserService;

    public AppDbContextFactory(IDateTime dateTime, ICurrentUserService currentUserService)
    {
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }

    public AppDbContextFactory()
    {
        
    }
    
    protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
    {
        return new AppDbContext(options , _currentUserService, _dateTime);
    }
}