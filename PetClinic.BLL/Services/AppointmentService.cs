using AutoMapper;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;


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
    public async Task AddAppointmentAsync(AddAppointmentDto appointment)
    {
        var result = mapper.Map<AppointmentEntity>(appointment);
        await unitOfWork.AppointmentRepository.AddAsync(result);
    }

    public void DeleteAppointment(Guid id)
    {
        var appointment = unitOfWork.AppointmentRepository.GetAsync(id);

        if(appointment is null)
        {
            throw Exceptions.Exceptions.AppointmentNotFound;
        }

        var result = mapper.Map<AppointmentEntity>(appointment);
        unitOfWork.AppointmentRepository.Remove(result);
    }

    public async Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetAsync(id);
        if (appointment is null)
        {
            throw Exceptions.Exceptions.AppointmentNotFound;
        }

      return mapper.Map<GetAppointmentDto>(appointment);
    }

    public async Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync()
    {
        var appointments = await unitOfWork.AppointmentRepository.GetAllAsync();

        if (appointments is null)
        {
            throw Exceptions.Exceptions.AppointmentsNotFound;
        }

        return mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);
    }

    public GetAppointmentDto UpdateAppointment(AddAppointmentDto appointment, Guid id)
    {
        var mappedItem = mapper.Map<AppointmentEntity>(appointment);
        mappedItem.Id = id;
        var result =  unitOfWork.AppointmentRepository.Update(mappedItem);

        return mapper.Map<GetAppointmentDto>(result);

    }
}
