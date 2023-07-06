using AutoMapper;
using FluentAssertions;
using Moq;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
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
    private readonly Mock<ICacheService> _cacheServiceMock;

    public PetServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _cacheServiceMock = new Mock<ICacheService>();
        _petService = new PetService(_unitOfWorkMock.Object, _mapperMock.Object, _cacheServiceMock.Object);
    }

    [Fact]
    public async Task GetPetsAsync_PetsExist_ShouldReturnPets()
    {
        // Arrange

        var expectedRepositoryData = new List<PetEntity>
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

        var expectedMapperData = new List<GetPetDto>
        {
            new GetPetDto
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                Name = "Coppy",
            },
            new GetPetDto
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                Name = "Poppy",
            },
            new GetPetDto
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                Name = "Moppy",
            }
        };

        _unitOfWorkMock.Setup(x => x.PetRepository.GetAllAsync())
            .ReturnsAsync(expectedRepositoryData);
        _mapperMock.Setup(x => x.Map<IEnumerable<GetPetDto>>(expectedRepositoryData))
            .Returns(expectedMapperData);

        // Act

        var pets = await _petService.GetPetsAsync();

        // Assert
        pets.Should().NotBeNull();
        pets.Should().NotBeEmpty();
        pets.Count().Should().Be(expectedRepositoryData.Count);
        pets.Should().BeEquivalentTo(expectedMapperData);
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

        pets.Should().NotBeNull();
        pets.Should().BeEquivalentTo(expectedData);
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

        IEnumerable<GetPetDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetPetDto>>(CacheKeys.petsKey))
            .ReturnsAsync(expectedCacheResult);
        _unitOfWorkMock.Setup(x => x.PetRepository.GetAsync(petId))
            .ReturnsAsync(expectedRepositoryResult);
        _mapperMock.Setup(x => x.Map<GetPetDto>(expectedRepositoryResult))
            .Returns(expectedResult);

        // Act

        var pet = await _petService.GetPetByIdAsync(petId);

        // Assert

        pet.Should().NotBeNull();
        pet.Should().BeEquivalentTo(expectedResult);
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

        Func<Task> act = async () => await _petService.GetPetByIdAsync(petId);

        // Assert

        await act.Should().ThrowAsync<NotFoundException>();
    }
}
