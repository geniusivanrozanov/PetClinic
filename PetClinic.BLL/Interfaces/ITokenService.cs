using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Interfaces;

public interface ITokenService
{
    Task<string> GenerateJwtTokenAsync(UserEntity user);
}
