using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class BaseEntity : IDeletable, ICreatedAt, IUpdatedAt
{
    public bool IsDeleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}