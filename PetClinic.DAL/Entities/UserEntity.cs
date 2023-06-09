using Microsoft.AspNetCore.Identity;

namespace PetClinic.DAL.Entities;

public class UserEntity : BaseEntity // : IdentityUser
{
    public string Login { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public Guid RoleId { get; set; }
    public RoleEntity Role { get; set; } = default!;

    public VetEntity Vet { get; set; } = default!;

    public List<PetEntity>? Pets { get; set; }
}
