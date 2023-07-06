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

namespace PetClinic.BLL.Tests.Tests;

public class AppointmentServiceTests
{
    private readonly AppointmentService _appointmentService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICacheService> _cacheServiceMock;

    public AppointmentServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _cacheServiceMock = new Mock<ICacheService>();
        _appointmentService = new AppointmentService(_unitOfWorkMock.Object, _mapperMock.Object, _cacheServiceMock.Object);
    }

    [Fact]
    public async Task GetAppointmentsAsync_AppointmentExist_ShouldReturnAppointments()
    {
        // Arrange

        var expectedRepositoryData = new List<AppointmentEntity>
        {
            new AppointmentEntity
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                DateTime = DateTime.Today,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new AppointmentEntity
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                DateTime = DateTime.Today,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            },
            new AppointmentEntity
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                DateTime = DateTime.Today,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
            }
        };

        var expectedMapperData = new List<GetAppointmentDto>
        {
            new GetAppointmentDto
            {
                Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                AppointmentDate = DateTime.Today,
            },
            new GetAppointmentDto
            {
                Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                AppointmentDate = DateTime.Today,
            },
            new GetAppointmentDto
            {
                Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                AppointmentDate = DateTime.Today,
            }
        };

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey))
            .ReturnsAsync(expectedMapperData);
        _unitOfWorkMock.Setup(x => x.AppointmentRepository.GetAllAsync())
            .ReturnsAsync(expectedRepositoryData);
        _mapperMock.Setup(x => x.Map<IEnumerable<GetAppointmentDto>>(expectedRepositoryData))
            .Returns(expectedMapperData);

        // Act

        var appointments = await _appointmentService.GetAppointmentsAsync();

        // Assert

        appointments.Should().NotBeNullOrEmpty();
        appointments.Should().BeEquivalentTo(expectedMapperData);
    }

    [Fact]
    public async Task GetAppointmentsAsync_AppointmentsIsEmpty_ShouldReturnEmptyList()
    {
        // Arrange

        var expectedData = new List<AppointmentEntity>() { };
        IEnumerable<GetAppointmentDto>? expectedCacheData = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey))
            .ReturnsAsync(expectedCacheData);
        _unitOfWorkMock.Setup(x => x.AppointmentRepository.GetAllAsync())
            .ReturnsAsync(expectedData);

        // Act

        var appointments = await _appointmentService.GetAppointmentsAsync();

        // Assert

        appointments.Should().NotBeNull();
        appointments.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task GetAppointmentByIdAsync_ValidData_ShouldReturnAppointment()
    {
        // Arrange

        var appointmentId = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd");

        var expectedRepositoryResult = new AppointmentEntity
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            DateTime = DateTime.Today
        };

        var expectedResult = new GetAppointmentDto
        {
            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
            AppointmentDate = DateTime.Today
        };

        IEnumerable<GetAppointmentDto>? expectedCacheResult = null;

        _cacheServiceMock.Setup(x => x.GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey))
            .ReturnsAsync(expectedCacheResult);
        _unitOfWorkMock.Setup(x => x.AppointmentRepository.GetAsync(appointmentId))
            .ReturnsAsync(expectedRepositoryResult);
        _mapperMock.Setup(x => x.Map<GetAppointmentDto>(expectedRepositoryResult))
            .Returns(expectedResult);

        // Act

        var appointment = await _appointmentService.GetAppointmentByIdAsync(appointmentId);

        // Assert

        appointment.Should().NotBeNull();
        appointment.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task GetAppointmentByIdAsync_AppointmentWithIdNotFound_ShouldThrowNotFoundException()
    {
        // Arrange

        var appointmentId = new Guid("c1e33d9b-1b7f-4cbd-95b0-644008a706e0");
        AppointmentEntity? expectedResult = null;

        _unitOfWorkMock.Setup(x => x.AppointmentRepository.GetAsync(appointmentId))
            .ReturnsAsync(expectedResult);

        // Act

        Func<Task> act = async () => await _appointmentService.GetAppointmentByIdAsync(appointmentId);

        // Assert

        await act.Should().ThrowAsync<NotFoundException>();
    }
}
