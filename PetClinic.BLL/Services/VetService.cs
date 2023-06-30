using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.ExceptionConstants;

namespace PetClinic.BLL.Services;

public class VetService : IVetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddReviewAsync(AddReviewDto review)
    {
        var result =  _mapper.Map<ReviewEntity>(review);

        var appointment = await _unitOfWork.AppointmentRepository.FindAsync(a => a.Id == review.AppointmentId) ?? 
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);
            
        var createdReview = await _unitOfWork.ReviewRepository.AddAsync(result);
        
        appointment.FirstOrDefault()!.ReviewId = createdReview.Id;

        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<GetVetDto>> GetVetsAsync()
    {
        var vets = await _unitOfWork.VetRepository.GetAllAsync() ?? 
            throw new NotFoundException(ExceptionMessages.VetsNotFound);

        return _mapper.Map<IEnumerable<GetVetDto>>(vets);
    }
    
    public async Task<GetVetDto> GetVetByIdAsync(Guid id)
    {
        var vet = await _unitOfWork.VetRepository.GetAsync(id) ??
            throw new NotFoundException(ExceptionMessages.VetsNotFound);

        return _mapper.Map<GetVetDto>(vet);
    }

    public async Task<IEnumerable<GetAppointmentDto>> GetScheduleAsync(GetScheduleDto schedule)
    {
        var serviceVet =  await _unitOfWork.ServiceVetRepository.FindAsync(x => x.VetId == schedule.VetId);
        var vets = serviceVet.Select(x => x.Id);
        var result = await _unitOfWork.AppointmentRepository
            .FindAsync(x => x.DateTime == schedule.AppointmentDate && 
                       vets.Contains(x.ServiceId));

        return _mapper.Map<IEnumerable<GetAppointmentDto>>(result);
    }
}
