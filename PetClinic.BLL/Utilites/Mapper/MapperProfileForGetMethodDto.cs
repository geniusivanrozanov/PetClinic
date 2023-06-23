using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForGetMethodDto : Profile
{
    public MapperProfileForGetMethodDto()
    {
        CreateMap<DepartmentEntity, GetDepartmentDto>();
        CreateMap<OrderCallEntity, GetOrderCallDto>();
        CreateMap<PetEntity, GetPetDto>();
        CreateMap<PetTypeEntity, GetPetTypeDto>();
        CreateMap<ServiceEntity, GetServiceDto>();
        CreateMap<UserEntity, GetUserDto>();
        CreateMap<VetEntity, GetVetDto>();
    }
}
