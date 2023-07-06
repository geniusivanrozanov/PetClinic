using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.API.Controllers;

[ApiController]
[ValidationFilter]
[Route("api/order-call")]
public class OrderCallController : ControllerBase
{
    private readonly IOrderCallService _orderCallService;

    public OrderCallController(IOrderCallService orderCallService)
    {
        _orderCallService = orderCallService;
    }

    [HttpGet]
    [Authorize(Roles = Roles.AdminRole)]
    public async Task<IActionResult> GetOrderCallsAsync()
    {
        var orderCalls = await _orderCallService.GetOrderCallsAsync();

        return Ok(orderCalls);
    }

    [HttpPost]
    [Authorize(Roles = Roles.ClientRole)]
    public async Task<IActionResult> CreateOrderCallAsync([FromBody] AddOrderCallDto orderCallDto)
    {
        await _orderCallService.CreateOrderAsync(orderCallDto);

        return Created("", orderCallDto);
    }
}
