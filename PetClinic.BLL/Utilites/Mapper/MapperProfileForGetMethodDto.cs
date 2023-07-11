using System.Globalization;
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
        CreateMap<UserEntity, GetUserDto>();
        CreateMap<VetEntity, GetVetDto>();
        
        CreateMap<ServiceEntity, GetServiceDto>();
        CreateMap<ServiceEntity, GetVetDto>();

        CreateMap<AppointmentEntity, GetAppointmentDto>()
            .ForMember(a => a.AppointmentDate, 
                ga => ga.MapFrom(a => a.DateTime.ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture)))
            .ForMember(a => a.PetName,
                ga => ga.MapFrom(a => a.Pet.Name))
            .ForMember(a => a.ServiceName, 
                ga => ga.MapFrom(a => a.Service.Service.Name))
            .ForMember(a => a.Comments,
                ga => ga.MapFrom(a => a.Review != null ? a.Review.VetComments : "No comments yet."))
            .ForMember(a => a.Diagnosis,
                ga => ga.MapFrom(a => a.Review != null ? a.Review.Diagnosis : "No diagnosis yet."));
    }
}
