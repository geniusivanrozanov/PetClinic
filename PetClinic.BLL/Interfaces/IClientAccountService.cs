using PetClinic.BLL.DTOs.AuthDto;

namespace PetClinic.BLL.Interfaces;

public interface IClientAccountService
{
    Task<string> RegisterUserAsync(UserRegistrationRequestDto userData);
    Task<string> LoginUserAsync(LoginUserDto userData);
}
