using PetClinic.BLL.DTOs.AddMethodDto;

namespace PetClinic.BLL.Interfaces;

public interface IOrderCallService
{
    Task CreateOrder(AddOrderCallDto callData);
}
