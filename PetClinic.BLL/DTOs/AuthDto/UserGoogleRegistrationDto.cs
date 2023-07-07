namespace PetClinic.BLL.DTOs.AuthDto;

public class UserGoogleRegistrationDto
{
    public string? UserName { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Password { get; set; }
}
