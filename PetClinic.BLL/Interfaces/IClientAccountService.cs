using PetClinic.BLL.DTOs.AuthDto;

namespace PetClinic.BLL.Interfaces;

public interface IClientAccountService
{
    Task<string> RegisterUser(UserRegistrationRequestDto userData);
}
