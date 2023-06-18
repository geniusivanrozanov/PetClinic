using System.Threading.Tasks;
using AutoMapper;
using Moq;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.Services;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using Xunit;

namespace PetClinic.BLL.Tests.Tests;

public class AppointmentServiceTests
{
    private readonly AppointmentService _appointmentService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

    public AppointmentServiceTests()
    {
        _appointmentService = new AppointmentService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task AddAppointmentAsync_ValidData_ShouldReturnOk()
    {
        // Arrange

        var addAppointmentDto = new AddAppointmentDto()
        {
            
        };

        var appointmentEntity = new AppointmentEntity()
        {
            
        };

        // var appointmentEntity = _mapperMock.Setup(m => m.Map<AppointmentEntity>(addAppointmentDto)).Returns(new AppointmentEntity(){ });
        _unitOfWorkMock.Setup(u => u.AppointmentRepository.AddAsync(appointmentEntity)).ReturnsAsync(appointmentEntity);

        // Act

        var result = await _appointmentService.AddAppointmentAsync(addAppointmentDto);

        // Assert

        Assert.NotNull(result);
    }
}
