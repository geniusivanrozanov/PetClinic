using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IUserAccountService
{
    Task<string> RegisterClientAsync(UserRegistrationRequestDto userData);
    Task<string> RegisterVetAccount(VetRegistrationRequestDto vetData);
    Task<string> LoginUserAsync(LoginUserDto userData);
    Task<IEnumerable<GetUserDto>> GetAllAccounts();
    Task UpdateUserAccount(UpdateUserAccountDto userData);
}
