namespace PetClinic.BLL.DTOs.AuthDto;

public class VetRegistrationRequestDto
{
    public UserRegistrationRequestDto AccountData { get; set; } = default!;
    public VetInfoDto VetInfo { get; set; } = default!;
}
