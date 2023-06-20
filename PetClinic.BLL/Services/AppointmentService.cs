using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.DTOs.UpdateMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;


namespace PetClinic.BLL.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<Guid> AddAppointmentAsync(AddAppointmentDto appointment)
    {
        var result = mapper.Map<AppointmentEntity>(appointment);
        var createdAppointment = await unitOfWork.AppointmentRepository.AddAsync(result);
        return createdAppointment.Id;
    }

    public async Task DeleteAppointmentAsync(Guid id)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetAsync(id);

        if (appointment is null)
        {
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);
        }

        var result = mapper.Map<AppointmentEntity>(appointment);
        unitOfWork.AppointmentRepository.Remove(result);
        await unitOfWork.CompleteAsync();
    }

    public async Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetAsync(id);

        if (appointment is null)
        {
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);
        }

        return mapper.Map<GetAppointmentDto>(appointment);
    }

    public async Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync()
    {
        var appointments = await unitOfWork.AppointmentRepository.GetAllAsync();

        if (appointments is null)
        {
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);
        }

        return mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);
    }

    public async Task<GetAppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment)
    {
        var mappedItem = mapper.Map<AppointmentEntity>(appointment);
        var result =  unitOfWork.AppointmentRepository.Update(mappedItem);
        await unitOfWork.CompleteAsync();

        return mapper.Map<GetAppointmentDto>(result);
    }
}
