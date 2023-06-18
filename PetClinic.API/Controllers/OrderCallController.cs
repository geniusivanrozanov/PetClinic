using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/order-call")]
public class OrderCallController : ControllerBase
{
    private readonly IOrderCallService _orderCallService;

    public OrderCallController(IOrderCallService orderCallService)
    {
        _orderCallService = orderCallService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderCallsAsync()
    {
        var orderCalls = await _orderCallService.GetOrderCallsAsync();

        return Ok(orderCalls);
    }

    [HttpPost]
<<<<<<< HEAD
    public async Task<IActionResult> CreateOrderCallAsync([FromBody] AddOrderCallDto orderCallDto)
=======
    public async Task<IActionResult> CreateOrderCallAsync(AddOrderCallDto orderCallDto)
>>>>>>> refs/remotes/origin/feature-api-layer
    {
        await _orderCallService.CreateOrderAsync(orderCallDto);

        return Created("", orderCallDto);
    }
}
