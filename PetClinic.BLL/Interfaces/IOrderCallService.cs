using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IOrderCallService
{
    Task<IEnumerable<GetOrderCallDto>> GetOrderCallsAsync();
    Task CreateOrderAsync(AddOrderCallDto callData);
}
