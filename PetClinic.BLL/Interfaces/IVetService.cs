using PetClinic.BLL.DTOs;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace PetClinic.BLL.Interfaces;

public interface IVetService
{
    Task AddReviewAsync(AddReviewDto review);
    Task<IEnumerable<GetAppointmentDto>> GetScheduleAsync(Expression<Func<GetAppointmentDto, bool>> predicate);
    Task<GetVetDto> GetVetByIdAsync(Guid id);
    Task<IEnumerable<GetVetDto>> GetVetsAsync();
}