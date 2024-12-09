using Domain.Common;

namespace Domain.Entities;

public class Branch : AuditableEntity<Guid>,ISoftDelete
{
    public string Address { get; set; }
    public Guid CompanyId { get; set; }
    public bool IsDeleted { get; set; }

    public Company Company { get; set; }
}