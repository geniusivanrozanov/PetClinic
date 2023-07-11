using System;
using System.Collections.Generic;
using System.Linq;
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

public class DepartmentServiceTests
{
    private readonly DepartmentService _departmentService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICacheService> _cacheServiceMock;

    public DepartmentServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _cacheServiceMock = new Mock<ICacheService>();
        _departmentService = new DepartmentService(_unitOfWorkMock.Object, _mapperMock.Object, _cacheServiceMock.Object);
    }

    [Fact]
    public async Task GetDepartmentsAsync_DepartmentsExist_ShouldReturnDepartments()
    {
        // Arrange

        var expectedData = new List<DepartmentEntity>
        {
            new DepartmentEntity
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                Address = "пр. Независимости, 177",
                Name = "Вет-клиника филиал 1",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new DepartmentEntity
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                Address = "ул. Академическая, 26",
                Name = "Вет-клиника филиал 2",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new DepartmentEntity
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                Address = "ул. Карастояновой, 2",
                Name = "Вет-клиника филиал 3",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            }
        };
        
        var expectedMapperResult = new List<GetDepartmentDto>
        {
            new GetDepartmentDto
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                Address = "пр. Независимости, 177",
                Name = "Вет-клиника филиал 1",
            },
            new GetDepartmentDto
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                Address = "ул. Академическая, 26",
                Name = "Вет-клиника филиал 2",
            },
            new GetDepartmentDto
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                Address = "ул. Карастояновой, 2",
                Name = "Вет-клиника филиал 3",
            }
        };

        IEnumerable<GetDepartmentDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetDepartmentDto>>(CacheKeys.appointmentsKey))
            .ReturnsAsync(expectedMapperResult);
        // _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAllAsync())
        //     .ReturnsAsync(expectedData);
        // _mapperMock.Setup(x => x.Map<IEnumerable<GetDepartmentDto>>(expectedData))
        //     .Returns(expectedMapperResult);

        // Act

        var departments = await _departmentService.GetDepartmentsAsync();

        // Assert

        departments.Should().NotBeNull();
        departments.Count().Should().Be(expectedMapperResult.Count);
    }

    [Fact]
    public async Task GetDepartmentsAsync_DepartmentsAreEmpty_ShouldThrowNotFoundException()
    {
        // Arrange

        IEnumerable<DepartmentEntity>? expectedData = null;

        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        Func<Task> act = async () => await _departmentService.GetDepartmentsAsync();

        // Assert

        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task GetDepartmentByIdAsync_ValidData_ShouldReturnDepartment()
    {
        // Arrange

        var departmentId = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd");
        
        var expectedRepositoryResult = new DepartmentEntity
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            Address = "пр. Независимости, 177",
            Name = "Вет-клиника филиал 1",
            Vets = new List<VetEntity>(),
        };

        var expectedResult = new GetDepartmentDto
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            Address = "пр. Независимости, 177",
            Name = "Вет-клиника филиал 1",
            Vets = new List<GetVetDto>(),
        };

        IEnumerable<GetDepartmentDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetDepartmentDto>>(CacheKeys.appointmentsKey))
            .ReturnsAsync(expectedCacheResult);
        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAsync(departmentId))
            .ReturnsAsync(expectedRepositoryResult);
        _mapperMock.Setup(x => x.Map<GetDepartmentDto>(expectedRepositoryResult))
            .Returns(expectedResult);

        // Act

        var department = await _departmentService.GetDepatmentByIdAsync(departmentId);

        // Assert

        department.Should().BeOfType<GetDepartmentDto>();
        department.Id.Should().Be(departmentId);
        department.Should().BeSameAs(expectedResult);
    }

    [Fact]
    public async Task GetDepartmentByIdAsync_DepartmentWithIdNotFound_ShouldThrowNotFoundException()
    {
        // Arrange

        var departmentId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        var expectedResult = new DepartmentEntity();
        var mapperResult = new GetDepartmentDto();

        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAsync(departmentId))
            .ReturnsAsync(expectedResult);

         _mapperMock.Setup(x => x.Map<GetDepartmentDto>(expectedResult))
            .Returns(mapperResult);

        // Act

        Func<Task> act = async () => await _departmentService.GetDepatmentByIdAsync(departmentId);

        // Assert

        await act.Should().ThrowAsync<NotFoundException>();
    }
}
