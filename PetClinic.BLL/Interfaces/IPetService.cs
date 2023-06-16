using PetClinic.BLL.DTOs;

namespace PetClinic.BLL.Interfaces;

public interface IPetService
{
    Task AddPetAsync(AddPetDto pet);
    Task<GetPetDto> GetPetByIdAsync(Guid id);
    Task<IEnumerable<GetPetDto>> GetPetsAsync();
    GetPetDto UpdatePet(AddPetDto pet, Guid ipd);
    void DeletePet(Guid id);
}
