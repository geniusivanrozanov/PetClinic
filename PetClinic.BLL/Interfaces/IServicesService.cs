using PetClinic.BLL.DTOs;

namespace PetClinic.BLL.Interfaces;

public interface IServicesService
{
    IEnumerable<GetServiceDto> GetServices();
    GetServiceDto GetServiceById(Guid serviceId);
}
