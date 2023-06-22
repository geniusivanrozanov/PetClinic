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
    private readonly ICacheService cachedService;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cachedService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.cachedService = cachedService;
    }
    
    public async Task AddAppointmentAsync(AddAppointmentDto appointment)
    {
        var result = mapper.Map<AppointmentEntity>(appointment);
        await unitOfWork.AppointmentRepository.AddAsync(result);

        await UpdateCacheAsync(CacheKeys.appointmentsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task DeleteAppointmentAsync(Guid id)
    {
        var appointment = await unitOfWork.AppointmentRepository.GetAsync(id) ?? 
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

        var result = mapper.Map<AppointmentEntity>(appointment);
        unitOfWork.AppointmentRepository.Remove(result);
        await unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.appointmentsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var cachedAppointments = await cachedService
            .GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey);

        if (cachedAppointments is null)
        {
            var appointment = await unitOfWork.AppointmentRepository.GetAsync(id) ?? 
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

            return mapper.Map<GetAppointmentDto>(appointment);
        }        

        var cachAppointment = cachedAppointments.Where(d => d.Id == id).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.DepartmentsNotFound);

        return cachAppointment;
    }

    public async Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync()
    {
        var cachedAppointments = await cachedService.GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey);
    
        if (cachedAppointments is null)
        {
            var appointments = await unitOfWork.AppointmentRepository.GetAllAsync() ??
                throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

            await cachedService.SetDataAsync(CacheKeys.appointmentsKey, appointments, DateTimeOffset.Now.AddMinutes(1));
            return mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);
        }

        return cachedAppointments;
    }

    public async Task<GetAppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment)
    {
        var mappedItem = mapper.Map<AppointmentEntity>(appointment);
        var result =  unitOfWork.AppointmentRepository.Update(mappedItem);
        await unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.appointmentsKey, DateTimeOffset.Now.AddMinutes(1));

        return mapper.Map<GetAppointmentDto>(result);
    }

    private async Task UpdateCacheAsync(string key, DateTimeOffset expiryTime)
    {
        var appointments = await unitOfWork.AppointmentRepository.GetAllAsync();
        var appointmentsDto = mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);

        await cachedService.SetDataAsync(key, appointmentsDto, expiryTime);
    }
}
