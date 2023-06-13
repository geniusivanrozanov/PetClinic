namespace PetClinic.BLL.DTOs;

public class AddUserDto
{
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public Guid RoleId { get; set; }
}
