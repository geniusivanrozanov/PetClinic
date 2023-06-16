using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IPetService
{
    Task AddPetAsync(AddPetDto pet);
    Task<GetPetDto> GetPetByIdAsync(Guid id);
    Task<IEnumerable<GetPetDto>> GetPetsAsync();
    GetPetDto UpdatePet(UpdatePetDto pet);
    void DeletePet(Guid id);
}
