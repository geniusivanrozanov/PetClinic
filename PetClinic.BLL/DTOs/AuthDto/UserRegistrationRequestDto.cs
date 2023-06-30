namespace PetClinic.BLL.DTOs.AuthDto;

public class UserRegistrationRequestDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? UserName { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = default!;
    public string? Password { get; set; }
}
