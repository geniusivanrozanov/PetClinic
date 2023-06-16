using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;


namespace PetClinic.BLL.Services;

public class PetService : IPetService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task AddPetAsync(AddPetDto pet)
    {
        var result = mapper.Map<PetEntity>(pet);
        await unitOfWork.PetRepository.AddAsync(result);
        await unitOfWork.CompleteAsync();
    }

    public void DeletePet(Guid id)
    {
        var pet = unitOfWork.PetRepository.GetAsync(id);

        if (pet is null)
        {
            throw new ArgumentNullException(); // Exceptions.Exceptions.PetNotFound;
        }

        var result = mapper.Map<PetEntity>(pet);
        unitOfWork.PetRepository.Remove(result);
        unitOfWork.Complete();
    }

    public async Task<GetPetDto> GetPetByIdAsync(Guid id)
    {
        var pet = await unitOfWork.PetRepository.GetAsync(id);
       
        if (pet is null)
        {
            throw new ArgumentNullException(); // Exceptions.Exceptions.PetNotFound;
        }

        return mapper.Map<GetPetDto>(pet);
    }

    public async Task<IEnumerable<GetPetDto>> GetPetsAsync()
    {
        var pets = await unitOfWork.PetRepository.GetAllAsync();

        if (pets is null)
        {
             throw new ArgumentNullException(); // Exceptions.Exceptions.PetsNotFound;
        }

        return mapper.Map<IEnumerable<GetPetDto>>(pets);
    }

    public GetPetDto UpdatePet(UpdatePetDto pet)
    {
        var mappedItem = mapper.Map<PetEntity>(pet);
        var result = unitOfWork.PetRepository.Update(mappedItem);
        unitOfWork.Complete();

        return mapper.Map<GetPetDto>(result);
    }
}
