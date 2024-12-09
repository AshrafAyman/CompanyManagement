using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicrblogApp.Persistence.Configurations;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.Email).IsRequired();

        builder.Property(e => e.Name).IsRequired();

        builder.HasOne(c => c.Branch)
            .WithOne(b => b.Company)
            .HasForeignKey<Branch>(b => b.CompanyId);
    }
}