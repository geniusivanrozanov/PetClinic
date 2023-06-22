using AutoMapper;
using Moq;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Services;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetClinic.BLL.Tests;

public class PetServiceTests
{
    private readonly PetService _petService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    public PetServiceTests()
    {
        _petService = new PetService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetPetsAsync_PetsExist_ShouldReturnPets()
    {
        // Arrange

        var expectedData = new List<PetEntity>
        {
                new PetEntity
                {
                    Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                    Name = "Coppy",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                },
                new PetEntity
                {
                    Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                    Name = "Poppy",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                },
                new PetEntity
                {
                    Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                    Name = "Moppy",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                }
        };

        _unitOfWorkMock.Setup(x => x.PetRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var pets = await _petService.GetPetsAsync();

        // Assert

        Assert.Equal(expectedData.Count, pets.ToList().Count);
    }

    [Fact]
    public async Task GetPetsAsync_PetsIsEmpty_ShouldReturnEmptyList()
    {
        // Arrange

        var expectedData = new List<PetEntity>() { };

        _unitOfWorkMock.Setup(x => x.PetRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var pets = await _petService.GetPetsAsync();

        // Assert

        Assert.Equal(pets, new List<GetPetDto>() { });
    }

    [Fact]
    public async Task GetPetByIdAsync_ValidData_ShouldReturnPet()
    {
        // Arrange

        var petId = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd");

        var expectedRepositoryResult = new PetEntity
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            Name = "Poppy"
        };

        var expectedResult = new GetPetDto
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            Name = "Poppy"
        };

        _unitOfWorkMock.Setup(x => x.PetRepository.GetAsync(petId))
            .ReturnsAsync(expectedRepositoryResult);
        _mapperMock.Setup(x => x.Map<GetPetDto>(expectedRepositoryResult))
            .Returns(expectedResult);

        // Act

        var pet = await _petService.GetPetByIdAsync(petId);

        // Assert

        Assert.Equal(petId, pet.Id);
    }

    [Fact]
    public async Task GetPetByIdAsync_PetWithIdNotFound_ShouldThrowNotFoundException()
    {
        // Arrange

        var petId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        PetEntity? expectedResult = null;

        _unitOfWorkMock.Setup(x => x.PetRepository.GetAsync(petId))
            .ReturnsAsync(expectedResult);

        // Act

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await _petService.GetPetByIdAsync(petId));
    }
}