using AutoMapper;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMapsForGetMethodDtos();
        CreateMapsForAddMethodDtos();
        CreateMapsForDeleteMethodDtos();
        CreateMapsForUpdateMethodDtos();
        CreateMapsForAuthDtos();
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

    private void CreateMapsForAddMethodDtos()
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

    private void CreateMapsForDeleteMethodDtos()
    {

    }

    private void CreateMapsForUpdateMethodDtos()
    {
        
    }

    private void CreateMapsForAuthDtos()
    {
        CreateMap<UserRegistrationRequestDto, UserEntity>();
        CreateMap<UpdateUserAccountDto, UserEntity>();
    }
}
