using AutoMapper;
using PetClinic.BLL.DTOs;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
       await unitOfWork.ReviewRepository.AddAsync(result);

    }

    public async Task<IEnumerable<GetVetDto>> GetVetsAsync()
    {
        var vets = await unitOfWork.VetRepository.GetAllAsync();

        if (vets is null)
        {
            throw Exceptions.Exceptions.VetsNotFound;
        }
     
        return mapper.Map<IEnumerable<GetVetDto>>(vets);
    }
    public async Task<GetVetDto> GetVetByIdAsync(Guid id)
    {
        var vet = await unitOfWork.VetRepository.GetAsync(id);

        if (vet is null)
        {
            throw Exceptions.Exceptions.VetNotFound;
        }
        return mapper.Map<GetVetDto>(vet);
    }

    public Task<IEnumerable<GetAppointmentDto>> GetScheduleAsync(Expression<Func<GetAppointmentDto, bool>> predicate)
    {
        throw new NotImplementedException();
    }

  


}
