using AutoMapper;
using PetClinic.BLL.DTOs.PagingDto;
using PetClinic.DAL.Features.Request.Paging.Parameters;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForPagingDto : Profile
{
    public MapperProfileForPagingDto()
    {
        CreateMap<PetTypeParametersDto, PetTypeParameters>(); 
    }
}
