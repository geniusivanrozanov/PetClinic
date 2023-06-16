using AutoMapper;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;

namespace PetClinic.BLL.Services;

public class OrderCallService : IOrderCallService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderCallService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateOrder(AddOrderCallDto callData)
    {
        var orderCallData = _mapper.Map<OrderCallEntity>(callData);

        await _unitOfWork.OrderCallRepository.AddAsync(orderCallData);
    }
}
