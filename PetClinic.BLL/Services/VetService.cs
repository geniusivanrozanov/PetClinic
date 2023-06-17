using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Exceptions;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

using ExceptionMessages = PetClinic.BLL.Exceptions.Exceptions;


namespace PetClinic.BLL.Services;

public class VetService : IVetService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public VetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task AddReviewAsync(AddReviewDto review)
    {
        var result =  mapper.Map<ReviewEntity>(review);

        var appointment = await unitOfWork.AppointmentRepository.FindAsync(a => a.Id == review.AppointmentId);
        
        if (appointment is null)
        {
            throw new NotFoundException(ExceptionMessages.AppointmentsNotFound);
        }

        var createdReview = await unitOfWork.ReviewRepository.AddAsync(result);
        
        appointment.FirstOrDefault()!.ReviewId = createdReview.Id;
    }

    public async Task<IEnumerable<GetVetDto>> GetVetsAsync()
    {
        var vets = await unitOfWork.VetRepository.GetAllAsync();

        if (vets is null)
        {
            throw new NotFoundException(ExceptionMessages.VetsNotFound);
        }
     
        return mapper.Map<IEnumerable<GetVetDto>>(vets);
    }
    
    public async Task<GetVetDto> GetVetByIdAsync(Guid id)
    {
        var vet = await unitOfWork.VetRepository.GetAsync(id);

        if (vet is null)
        {
            throw new NotFoundException(ExceptionMessages.VetsNotFound);
        }

        return mapper.Map<GetVetDto>(vet);
    }

    public async Task<IEnumerable<GetAppointmentDto>> GetScheduleAsync(GetScheduleDto schedule)
    {
        var serviceVet =  await unitOfWork.ServiceVetRepository.FindAsync(x => x.VetId == schedule.VetId);
        var vets = serviceVet.Select(x => x.Id);
        var result = await unitOfWork.AppointmentRepository.FindAsync(x => DateOnly.FromDateTime(x.DateTime) == schedule.AppointmentDate && vets.Contains(x.ServiceId));

        return mapper.Map<IEnumerable<GetAppointmentDto>>(result);
    }
}
