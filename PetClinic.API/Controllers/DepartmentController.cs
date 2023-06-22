using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetDepartmentsAsync()
    {        
        var departments = await _departmentService.GetDepartmentsAsync();

        return Ok(departments);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetDepartmentByIdAsync([FromRoute] Guid id)
    {            
        var department = await _departmentService.GetDepatmentByIdAsync(id);

        return Ok(department);
    }
}
