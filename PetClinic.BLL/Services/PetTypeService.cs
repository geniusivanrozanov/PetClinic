using AutoMapper;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.Exceptions;


namespace PetClinic.BLL.Services;

public class PetTypeService : IPetTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PetTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<GetPetTypeDto>> GetPetTypes()
    {
        var petTypes = await _unitOfWork.PetTypeRepository.GetAllAsync();

        if (petTypes is null)
        {
            throw new NotFoundException(ExceptionMessages.PetTypeNotFound);
        }

        return _mapper.Map<IEnumerable<GetPetTypeDto>>(petTypes);
    }
}
