using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IOrderCallService
{
    Task<GetOrderCallDto> GetOrderCallsAsync();
    Task CreateOrderAsync(AddOrderCallDto callData);
}
