namespace PetClinic.BLL.DTOs.AuthDto;

public class VetRegistrationRequestDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Experience { get; set; } = default!;
    public string Bio { get; set; } = default!;
    public Guid DepatmentId { get; set; }
}
