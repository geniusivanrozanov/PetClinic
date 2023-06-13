using Microsoft.AspNetCore.Identity;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class RoleEntity : IdentityRole<Guid>, IEntity<Guid>
{
    public bool IsDeleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public virtual List<UserEntity>? Users { get; set; }
}