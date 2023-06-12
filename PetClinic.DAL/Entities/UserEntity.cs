using Microsoft.AspNetCore.Identity;

namespace PetClinic.DAL.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public VetEntity Vet { get; set; } = default!;

    public List<PetEntity>? Pets { get; set; }
}
