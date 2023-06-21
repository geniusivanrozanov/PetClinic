using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IServicesService
{
    Task<IEnumerable<GetServiceDto>> GetServicesAsync();
    Task<GetServiceDto> GetServiceByIdAsync(Guid serviceId);
}
