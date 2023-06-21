using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Services;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using Xunit;

namespace PetClinic.BLL.Tests;

public class ServicesServiceTests
{
    private readonly ServicesService _servicesService;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork = new ();
    private readonly Mock<IMapper> _mockMapper = new ();

    public ServicesServiceTests()
    {
        _servicesService = new ServicesService(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetServicesAsync_ServicesExist_ShouldReturnServices()
    {
        // Arrange
        
        var expectedRepositoryResult = new List<ServiceEntity>
        {
            new ServiceEntity
            {
                Id = new Guid("afc747bf-2c6f-4c6a-88e9-1385cef793d6"),
                Name = "Intestinal Parasite Screening",
                Price = 25,
                Duration = "40",
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
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
            }
        };

        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAllAsync())
            .ReturnsAsync(expectedRepositoryResult);
        _mockMapper.Setup(x => x.Map<IEnumerable<GetServiceDto>>(expectedRepositoryResult))
            .Returns(expectedMapperResult);

        // Act

        var services = await _servicesService.GetServicesAsync();

        // Assert

        Assert.NotNull(services);
        Assert.True(services.Any());
        Assert.Equal(expectedMapperResult, services);
    }
    
    [Fact]
    public async Task GetServicesAsync_ServicesDoesnNotExist_ShouldReturnEmptyList()
    {
        // Arrange
        
        var expectedRepositoryResult = new List<ServiceEntity> {};

        var expectedMapperResult = new List<GetServiceDto> {};

        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAllAsync())
            .ReturnsAsync(expectedRepositoryResult);
        _mockMapper.Setup(x => x.Map<IEnumerable<GetServiceDto>>(expectedRepositoryResult))
            .Returns(expectedMapperResult);

        // Act

        var services = await _servicesService.GetServicesAsync();

        // Assert

        Assert.NotNull(services);
        Assert.True(!services.Any());
        Assert.Equal(expectedMapperResult, services);
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

        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAsync(serviceId))
            .ReturnsAsync(expectedRepositoryResult);
        _mockMapper.Setup(x => x.Map<GetServiceDto>(expectedRepositoryResult))
            .Returns(expectedMapperResult);
        
        // Act

        var service = await _servicesService.GetServiceByIdAsync(serviceId);

        // Assert

        Assert.NotNull(service);
        Assert.Equal(serviceId, service.Id);
        Assert.Equal(expectedMapperResult, service);
    }

    [Fact]
    public async Task GetServiceByIdAsync_ServiceNotFound_ShouldReturnEmptyEntity()
    {
        // Arrange
        
        var serviceId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        var expectedResult = new ServiceEntity();
        var mapperResult = new GetServiceDto();

        _mockUnitOfWork.Setup(x => x.ServiceRepository.GetAsync(serviceId))
            .ReturnsAsync(expectedResult);

         _mockMapper.Setup(x => x.Map<GetServiceDto>(expectedResult))
            .Returns(mapperResult);

        // Act

        var service = await _servicesService.GetServiceByIdAsync(serviceId);

        // Assert

        Assert.NotNull(service);
    }
}
