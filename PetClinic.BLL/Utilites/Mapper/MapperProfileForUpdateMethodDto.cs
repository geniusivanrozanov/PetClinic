using AutoMapper;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.DAL.Entities;

namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForUpdateMethodDto : Profile
{
    public MapperProfileForUpdateMethodDto()
    {
        CreateMap<UpdateAppointmentDto, AppointmentEntity>();
        CreateMap<UpdatePetDto, PetEntity>();
    }
}
