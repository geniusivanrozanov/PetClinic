using AutoMapper;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForUpdateMethodDto : Profile
{
    public MapperProfileForUpdateMethodDto()
    {
        CreateMap<UpdateAppointmentDto, AppointmentEntity>()
            .ForMember(a => a.ServiceId, 
                d => d.MapFrom(aa => new Guid(aa.ServiceId)))
            .ForMember(a => a.PetId, 
                d => d.MapFrom(aa => new Guid(aa.PetId)))
            .ForMember(a => a.DateTime,
                d => d.MapFrom(aa => aa.AppointmentDateAndTime.ToUniversalTime()));
        CreateMap<UpdatePetDto, PetEntity>();
    }
}
