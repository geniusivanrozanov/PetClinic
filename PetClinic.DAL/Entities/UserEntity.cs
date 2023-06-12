using Microsoft.AspNetCore.Identity;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Entities;

public class UserEntity : IdentityUser<Guid>, IEntity<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid RoleId { get; set; }
    public RoleEntity Role { get; set; } = default!;

    public VetEntity Vet { get; set; } = default!;

    public List<PetEntity>? Pets { get; set; }
}
