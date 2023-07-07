using Google.Apis.Auth.OAuth2.Responses;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IUserAccountService
{
    string GetAuthString();
    Task<string> RegisterUserWithGoogle(string code);
    Task<string> RegisterClientAsync(UserRegistrationRequestDto userData);
    Task<string> RegisterVetAccount(VetRegistrationRequestDto vetData);
    Task<string> LoginUserAsync(LoginUserDto userData);
    Task<IEnumerable<GetUserDto>> GetAllAccounts();
    Task UpdateUserAccount(UpdateUserAccountDto userData);
}
