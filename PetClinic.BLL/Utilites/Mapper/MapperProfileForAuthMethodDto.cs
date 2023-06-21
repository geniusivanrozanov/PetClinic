using AutoMapper;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForAuthMethodDto : Profile
{
    public MapperProfileForAuthMethodDto()
    {
        CreateMap<UserRegistrationRequestDto, UserEntity>();
        CreateMap<UpdateUserAccountDto, UserEntity>();
    }
}
