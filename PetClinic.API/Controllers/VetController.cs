﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.API.Middlewares.Filters;
using PetClinic.BLL.DTOs.AddMethodDto;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Entities;

namespace PetClinic.API.Controllers;

[ApiController]
[ValidationFilter]
[Route("api/vets")]
public class VetController : ControllerBase
{
    private readonly IVetService _vetService;

    public VetController(IVetService vetService)
    {
        _vetService = vetService;
    }

    [HttpPost("review")]
    [Authorize(Roles = $"{Roles.VetRole}")]
    public async Task<IActionResult> AddAsync([FromBody] AddReviewDto review)
    {
        await _vetService.AddReviewAsync(review);

        return Created("", review);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _vetService.GetVetByIdAsync(id));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _vetService.GetVetsAsync());
    }

    [HttpGet("{vetId}/shedule/{appointmentDate}")]
    [Authorize(Roles = $"{Roles.VetRole}, {Roles.AdminRole}")]
    public async Task<IActionResult> GetScheduleAsync(DateTime appointmentDate, Guid vetId)
    {
        var getScheduleDto = new GetScheduleDto
        {
            AppointmentDate = appointmentDate,
            VetId = vetId,
        };

        return Ok(await _vetService.GetScheduleAsync(getScheduleDto));
    }
}
