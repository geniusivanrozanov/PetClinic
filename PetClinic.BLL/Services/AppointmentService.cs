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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICacheService _cachedService;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cachedService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cachedService = cachedService;
    }
    
    public async Task AddAppointmentAsync(AddAppointmentDto appointment)
    {
        var result = _mapper.Map<AppointmentEntity>(appointment);
        await _unitOfWork.AppointmentRepository.AddAppointmentAsync(result);
        await _unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.appointmentsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task DeleteAppointmentAsync(Guid id)
    {
        var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentAsync(id) ?? 
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

        var result = _mapper.Map<AppointmentEntity>(appointment);
        _unitOfWork.AppointmentRepository.RemoveAppointment(result);
        await _unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.appointmentsKey, DateTimeOffset.Now.AddMinutes(1));
    }

    public async Task<GetAppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var cachedAppointments = await _cachedService
            .GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey);

        if (cachedAppointments is null)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentAsync(id) ?? 
                throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

            return _mapper.Map<GetAppointmentDto>(appointment);
        }        

        var cachAppointment = cachedAppointments.Where(d => d.Id == id).FirstOrDefault() ??
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);

        return cachAppointment;
    }

    public async Task<IEnumerable<GetAppointmentDto>> GetAppointmentsAsync(Guid userId)
    {
        var cachedAppointments = await _cachedService.GetDataAsync<IEnumerable<GetAppointmentDto>>(CacheKeys.appointmentsKey+userId.ToString());
        
        if (cachedAppointments is null)
        {
            var appointments = await _unitOfWork.AppointmentRepository.FindAppointmentAsync(x => x.Pet.ClientId == userId) ??
                throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);
            
            var appointmentsDto = _mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);
            
            await _cachedService.SetDataAsync(CacheKeys.appointmentsKey + userId.ToString(), appointmentsDto, DateTimeOffset.Now.AddMinutes(1));

            return appointmentsDto;
        }

        return cachedAppointments;
    }

    public async Task<GetAppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto appointment)
    {
        var mappedItem = _mapper.Map<AppointmentEntity>(appointment);
        var result =  _unitOfWork.AppointmentRepository.UpdateAppointment(mappedItem);
        await _unitOfWork.CompleteAsync();

        await UpdateCacheAsync(CacheKeys.appointmentsKey, DateTimeOffset.Now.AddMinutes(1));

        return _mapper.Map<GetAppointmentDto>(result);
    }

    private async Task UpdateCacheAsync(string key, DateTimeOffset expiryTime)
    {
        var appointments = await _unitOfWork.AppointmentRepository.GetAllAppointmentsAsync();
        var appointmentsDto = _mapper.Map<IEnumerable<GetAppointmentDto>>(appointments);

        await _cachedService.SetDataAsync(key, appointmentsDto, expiryTime);
    }
}
