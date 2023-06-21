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

public class DepartmentServiceTests
{
    private readonly DepartmentService _departmentService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new ();
    private readonly Mock<IMapper> _mapperMock = new ();

    public DepartmentServiceTests()
    {
        _departmentService = new DepartmentService(_unitOfWorkMock.Object, _mapperMock.Object);
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

        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var departments = await _departmentService.GetDepartmentsAsync();

        // Assert

        Assert.Equal(expectedData.Count, departments.ToList().Count);
    }

    [Fact]
    public async Task GetDepartmentsAsync_DepartmentsIsEmpty_ShouldReturnEmptyList()
    {
        // Arrange

        var expectedData = new List<DepartmentEntity>() {};

        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var departments = await _departmentService.GetDepartmentsAsync();

        // Assert

        Assert.Equal(departments, new List<GetDepartmentDto>(){});
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

        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAsync(departmentId))
            .ReturnsAsync(expectedRepositoryResult);
        _mapperMock.Setup(x => x.Map<GetDepartmentDto>(expectedRepositoryResult))
            .Returns(expectedResult);

        // Act

        var department = await _departmentService.GetDepatmentByIdAsync(departmentId);

        // Assert

        Assert.Equal(departmentId, department.Id);
    }

    [Fact]
    public async Task GetDepartmentByIdAsync_DepartmentWithIdNothFound_ShouldReturnEmpty()
    {
        // Arrange

        var departmentId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        var expectedResult = new DepartmentEntity();
        var mapperResult = new GetDepartmentDto();

        _unitOfWorkMock.Setup(x => x.DepartmentRepository.GetAsync(departmentId))
            .ReturnsAsync(expectedResult);
            // .Throws(new Exceptions.NotFoundException()); // я в выбросе исключений не уверена

         _mapperMock.Setup(x => x.Map<GetDepartmentDto>(expectedResult))
            .Returns(mapperResult);

        // Act

        var department = await _departmentService.GetDepatmentByIdAsync(departmentId);

        // Assert

        Assert.NotNull(department);
    }
}
