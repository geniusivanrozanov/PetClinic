using Microsoft.AspNetCore.Identity;

namespace PetClinic.DAL.Entities;

public class RoleEntity : IdentityRole<Guid>
{
    public bool IsDeleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public List<UserEntity>? Users { get; set; }
}