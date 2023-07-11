using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.PagingDto;
using PetClinic.DAL.Features.Request.Paging;

namespace PetClinic.BLL.Interfaces;

public interface IPetTypeService
{
    Task<IEnumerable<GetPetTypeDto>> GetPetTypesAsync();
    Task<PagedList<GetPetTypeDto>> GetPetTypesPagedAsync(PetTypeParametersDto petTypeParametersDto);  
}
