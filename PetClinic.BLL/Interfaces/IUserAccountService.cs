using PetClinic.BLL.DTOs;
using PetClinic.BLL.DTOs.AuthDto;

namespace PetClinic.BLL.Interfaces;

public interface IUserAccountService
{
    Task<string> RegisterClientAsync(UserRegistrationRequestDto userData);
    Task<string> RegisterVetAccount(UserRegistrationRequestDto userData, AddVetDto vetData);
    Task<string> LoginUserAsync(LoginUserDto userData);
    Task<IEnumerable<GetUserDto>> GetAllAccounts();
    Task UpdateUserAccount(UpdateUserAccountDto userData);
}
