namespace PetClinic.DAL.Entities;

public class RoleEntity : BaseEntity // : IdentityRole<Guid>
{
    public string Name { get; set; } = default!;

    public List<UserEntity>? Users { get; set; }
}