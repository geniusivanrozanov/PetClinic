using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/Pet")]
public class PetController
{
    private readonly IPetService petService;

    public PetController(IPetService petService)
    {
        this.petService = petService;
    }


    [HttpPost]
    public async Task Add(AddPetDto pet)
    {
        await petService.AddPetAsync(pet);
    }

    [HttpGet("id")]
    public async Task<GetPetDto> GetById(Guid id)
    {
        return await petService.GetPetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<GetPetDto>> GetAll()
    {
        return await petService.GetPetsAsync();
    }

    [HttpDelete("id")]
    public void Delete(Guid id)
    {
        petService.DeletePet(id);
    }

    [HttpPut("id")]
    public GetPetDto Update(AddPetDto appointment, Guid id)
    {
        return petService.UpdatePet(appointment, id);
    }
}
