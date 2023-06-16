using PetClinic.BLL.DTOs;

namespace PetClinic.BLL.Interfaces;

public interface IServicesService
{
    Task<IEnumerable<GetServiceDto>> GetServicesAsync();
    Task<GetServiceDto> GetServiceByIdAsync(Guid serviceId);
}
