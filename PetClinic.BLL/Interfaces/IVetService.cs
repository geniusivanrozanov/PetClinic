using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;


namespace PetClinic.BLL.Interfaces;

public interface IVetService
{
    Task AddReviewAsync(AddReviewDto review);
    Task<IEnumerable<GetAppointmentDto>> GetScheduleAsync(GetScheduleDto schedule);
    Task<GetVetDto> GetVetByIdAsync(Guid id);
    Task<IEnumerable<GetVetDto>> GetVetsAsync();
}
