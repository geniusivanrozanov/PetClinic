namespace PetClinic.BLL.DTOs.AuthDto;

public class UserGoogleRegistrationDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}
