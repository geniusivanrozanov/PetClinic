using AutoMapper;
using PetClinic.BLL.DTOs;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMapsForGetMethodDtos();
        CreateMappsForAddMethodDtos();
        CreateMappsForDeleteMethodDtos();
        CreateMappsForUpdateMethodDtos();
    }

    private void CreateMapsForGetMethodDtos()
    {
        CreateMap<DepartmentEntity, GetDepartmentDto>();
        CreateMap<OrderCallEntity, GetOrderCallDto>();
        CreateMap<PetEntity, GetPetDto>();
        CreateMap<PetTypeEntity, GetPetTypeDto>();
        CreateMap<ServiceEntity, GetServiceDto>();
        CreateMap<StatusEntity, GetStatusDto>();
        CreateMap<UserEntity, GetUserDto>();
    }

    private void CreateMappsForAddMethodDtos()
    {
        CreateMap<AddAppointmentDto, AppointmentEntity>()
            .ForMember(a => a.DateTime, 
                d => d
                    .MapFrom(aa => DateTime.Parse(aa.AppointmentDateAndTime)
                        .ToUniversalTime()));

        CreateMap<AddPetDto, PetEntity>();
        CreateMap<AddReviewDto, ReviewEntity>();
        CreateMap<AddServiceDto, ServiceEntity>();
        CreateMap<AddUserDto, UserEntity>();
        CreateMap<AddVetDto, VetEntity>();
    }

    private void CreateMappsForDeleteMethodDtos()
    {

    }

    private void CreateMappsForUpdateMethodDtos()
    {

    }
}
