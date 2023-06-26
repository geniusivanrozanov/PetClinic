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

public class VetServiceTests
{
    private readonly VetService _vetService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    public VetServiceTests()
    {
        _vetService = new VetService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetVetsAsync_VetsExist_ShouldReturnVets()
    {
        // Arrange

        var expectedData = new List<VetEntity>
        {
                new VetEntity
                {
                    Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                    FirstName = "Alex",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                },
                new VetEntity
                {
                    Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                    FirstName = "David",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                },
                new VetEntity
                {
                    Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                    FirstName = "John",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                }
        };

        _unitOfWorkMock.Setup(x => x.VetRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var pets = await _vetService.GetVetsAsync();

        // Assert

        Assert.Equal(expectedData.Count, pets.ToList().Count);
    }

    [Fact]
    public async Task GetVetsAsync_VetsIsEmpty_ShouldReturnEmptyList()
    {
        // Arrange

        var expectedData = new List<VetEntity>() { };

        _unitOfWorkMock.Setup(x => x.VetRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var vets = await _vetService.GetVetsAsync();

        // Assert

        Assert.Equal(vets, new List<GetVetDto>() { });
    }

    [Fact]
    public async Task GetVetByIdAsync_ValidData_ShouldReturnVet()
    {
        // Arrange

        var vetId = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd");

        var expectedRepositoryResult = new VetEntity
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            FirstName = "David"
        };

        var expectedResult = new GetVetDto
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            FirstName = "David"
        };

        _unitOfWorkMock.Setup(x => x.VetRepository.GetAsync(vetId))
            .ReturnsAsync(expectedRepositoryResult);
        _mapperMock.Setup(x => x.Map<GetVetDto>(expectedRepositoryResult))
            .Returns(expectedResult);

        // Act

        var vet = await _vetService.GetVetByIdAsync(vetId);

        // Assert

        Assert.Equal(vetId, vet.Id);
    }

    [Fact]
    public async Task GetVetByIdAsync_VetWithIdNotFound_ShouldThrowNotFoundException()
    {
        // Arrange

        var vetId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        VetEntity? expectedResult = null;

        _unitOfWorkMock.Setup(x => x.VetRepository.GetAsync(vetId))
            .ReturnsAsync(expectedResult);

        // Act

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await _vetService.GetVetByIdAsync(vetId));
    }
}