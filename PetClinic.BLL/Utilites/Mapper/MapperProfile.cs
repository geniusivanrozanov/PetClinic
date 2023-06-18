using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMapsForGetMethodDtos();
        CreateMapsForAddMethodDtos();
        CreateMapsForUpdateMethodDtos();
        CreateMapsForAuthDtos();
    }

    private void CreateMapsForGetMethodDtos()
    {
        CreateMap<VetEntity, GetVetDto>();
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
                d => d.MapFrom(aa => DateTime.Parse(aa.AppointmentDateAndTime)
                    .ToUniversalTime()));

        CreateMap<AddPetDto, PetEntity>()
            .ForMember(p => p.ClientId,
                k => k.MapFrom(v => new Guid(v.ClientId)))
            .ForMember(d => d.PetTypeId, 
                p => p.MapFrom(f => new Guid(f.PetTypeId)));

        CreateMap<AddReviewDto, ReviewEntity>();
        CreateMap<AddServiceDto, ServiceEntity>();
        CreateMap<AddVetDto, VetEntity>();
    }

    private void CreateMapsForUpdateMethodDtos()
    {
        CreateMap<UpdateAppointmentDto, AppointmentEntity>();
        CreateMap<UpdatePetDto, PetEntity>();
    }

    private void CreateMapsForAuthDtos()
    {
        CreateMap<UserRegistrationRequestDto, UserEntity>();
        CreateMap<UpdateUserAccountDto, UserEntity>();
        CreateMap<VetRegistrationRequestDto, UserRegistrationRequestDto>();
        CreateMap<VetInfoDto, AddVetDto>()
            .ForMember(v => v.DepartmentId,
                 av => av.MapFrom(v => new Guid(v.DepatmentId)));
    }
}
