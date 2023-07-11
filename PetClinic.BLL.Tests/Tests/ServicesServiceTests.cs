using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.BLL.Services;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using Xunit;

namespace PetClinic.BLL.Tests;

public class ServicesServiceTests
{
    private readonly ServicesService _servicesService;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ICacheService> _cacheServiceMock;

    public ServicesServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _cacheServiceMock = new Mock<ICacheService>();
        _servicesService = new ServicesService(_mockUnitOfWork.Object, _mockMapper.Object, _cacheServiceMock.Object);
    }

    [Fact]
    public async Task GetServicesAsync_ServicesExist_ShouldReturnServices()
    {
        // Arrange
        
        var expecteRepositoryResult = new List<ServiceEntity>
        {
            new ServiceEntity
            {
                Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
                Name = "Intestinal Parasite Screening",
                Price = 25,
                Duration = "40",
                ServiceVets = new List<ServiceVetEntity>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            }
        };

        var expectedMapperResult = new List<GetServiceDto>
        {
            new GetServiceDto
            {
                Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
                Name = "Intestinal Parasite Screening",
                Price = 25,
                Duration = "40",
                VetId = new Guid("3f491d6e-c1cc-41b5-95ca-8a9d32175020"),
            }
        };

        IEnumerable<GetServiceDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey))
             .ReturnsAsync(expectedCacheResult);
        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAllAsync())
            .ReturnsAsync(expecteRepositoryResult);
        _mockMapper.Setup(x => x.Map<IEnumerable<GetServiceDto>>(expecteRepositoryResult))
            .Returns(expectedMapperResult);

        // Act

        var services = await _servicesService.GetServicesAsync();

        // Assert

        services.Should().NotBeNullOrEmpty();
        services.Should().BeEquivalentTo(expecteRepositoryResult);
    }
    
    [Fact]
    public async Task GetServicesAsync_ServicesDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        
        IEnumerable<ServiceEntity>? expectedRepositoryResult = null;
        IEnumerable<GetServiceDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey))
            .ReturnsAsync(expectedCacheResult);
        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAllAsync())
            .ReturnsAsync(expectedRepositoryResult);

        // Act

        Func<Task> act = async () => await _servicesService.GetServicesAsync();

        // Assert

        await act.Should().ThrowAsync<NotFoundException>();
    }
    
    [Fact]
    public async Task GetServiceByIdAsync_ServiceExists_ShouldReturnService()
    {
        // Arrange

        var serviceId = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6");

        var expectedRepositoryResult = new ServiceEntity
        {
            Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
            Name = "Intestinal Parasite Screening",
            Price = 25,
            Duration = "40",
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        var expectedMapperResult = new GetServiceDto
        {
            Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
            Name = "Intestinal Parasite Screening",
            Price = 25,
            Duration = "40",
        };

        IEnumerable<GetServiceDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey))
            .ReturnsAsync(expectedCacheResult);
        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAsync(serviceId))
            .ReturnsAsync(expectedRepositoryResult);
        _mockMapper.Setup(x => x.Map<GetServiceDto>(expectedRepositoryResult))
            .Returns(expectedMapperResult);
        
        // Act

        var service = await _servicesService.GetServiceByIdAsync(serviceId);

        // Assert

        service.Should().BeEquivalentTo(expectedMapperResult);        
    }

    [Fact]
    public async Task GetServiceByIdAsync_ServiceNotFound_ShouldThrowNotFoundException()
    {
        // Arrange
        
        var serviceId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        ServiceEntity? expectedResult = null;
        var mapperResult = new GetServiceDto();
        IEnumerable<GetServiceDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetServiceDto>>(CacheKeys.servicesKey))
            .ReturnsAsync(expectedCacheResult);
        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAsync(serviceId))
            .ReturnsAsync(expectedResult);
        _mockMapper.Setup(x => x.Map<GetServiceDto>(expectedResult))
            .Returns(mapperResult);

        // Act

        Func<Task> act = async () => await _servicesService.GetServiceByIdAsync(serviceId);

        // Assert

        await act.Should().ThrowAsync<NotFoundException>();
    }
}
