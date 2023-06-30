using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.AuthDto;
using PetClinic.DAL.Entities;


namespace PetClinic.BLL.Utilites.Mapper;

public class MapperProfileForAuthMethodDto : Profile
{
    public MapperProfileForAuthMethodDto()
    {
        CreateMap<UserRegistrationRequestDto, UserEntity>();
        CreateMap<UserGoogleRegistrationDto, UserRegistrationRequestDto>();
        CreateMap<GoogleDataResponse, UserGoogleRegistrationDto>()
            .ForMember(g => g.FirstName, gd => gd
                .MapFrom(gd => gd.GivenName))
            .ForMember(g => g.LastName, gd => gd
                .MapFrom(gd => gd.FamilyName));
    
        CreateMap<UpdateUserAccountDto, UserEntity>();
        CreateMap<UserGoogleRegistrationDto, UserEntity>();
        CreateMap<VetInfoDto, AddVetDto>()
            .ForMember(vi => vi.DepartmentId,
                av => av
                    .MapFrom(av => new Guid(av.DepatmentId)));
    }
}
