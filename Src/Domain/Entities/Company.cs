using Domain.Common;

namespace Domain.Entities;

public class Company : AuditableEntity<Guid> , ISoftDelete
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
    public Branch Branch { get; set; }
}