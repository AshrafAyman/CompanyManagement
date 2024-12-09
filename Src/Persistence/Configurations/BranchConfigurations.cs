using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicrblogApp.Persistence.Configurations;

public class BranchConfigurations :IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasQueryFilter(e => !e.IsDeleted);
        builder.Property(e => e.Address).IsRequired();
    }
}