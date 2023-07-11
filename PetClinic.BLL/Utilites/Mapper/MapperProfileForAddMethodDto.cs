using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForAddMethodDto : Profile
{
    public MapperProfileForAddMethodDto()
    {
        CreateMap<AddAppointmentDto, AppointmentEntity>()
            .ForMember(a => a.ServiceId, 
                d => d.MapFrom(aa => new Guid(aa.ServiceId)))
            .ForMember(a => a.PetId, 
                d => d.MapFrom(aa => new Guid(aa.PetId)))
            .ForMember(a => a.DateTime,
                d => d.MapFrom(aa => aa.AppointmentDateAndTime.ToUniversalTime()));

        CreateMap<AddPetDto, PetEntity>();
        CreateMap<AddReviewDto, ReviewEntity>();
        CreateMap<AddServiceDto, ServiceEntity>();
        CreateMap<AddVetDto, VetEntity>();
        CreateMap<AddOrderCallDto, OrderCallEntity>();
    }
}

