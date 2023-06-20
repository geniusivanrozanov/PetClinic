using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IPetTypeService
{
    Task<IEnumerable<GetPetTypeDto>> GetPetTypes();  
}
