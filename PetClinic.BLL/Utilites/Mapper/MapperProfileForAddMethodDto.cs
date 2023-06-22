using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForAddMethodDto : Profile
{
    public MapperProfileForAddMethodDto()
    {
        CreateMap<AddAppointmentDto, AppointmentEntity>();
        // .ForMember(a => a.DateTime, 
        //     d => d
        //         .MapFrom(aa => DateTime.Parse(aa.AppointmentDateAndTime)
        //             .ToUniversalTime()));

        CreateMap<AddPetDto, PetEntity>();
        CreateMap<AddReviewDto, ReviewEntity>();
        CreateMap<AddServiceDto, ServiceEntity>();
        CreateMap<AddVetDto, VetEntity>();
        CreateMap<AddOrderCallDto, OrderCallEntity>();
    }
}
