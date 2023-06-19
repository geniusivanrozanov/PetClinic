using Microsoft.AspNetCore.Mvc;
using PetClinic.BLL.DTOs.GetMethodDto;
using PetClinic.BLL.Interfaces;

namespace PetClinic.API.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ICacheService _cacheService;

        public DepartmentController(
            IDepartmentService departmentService, 
            ICacheService cacheService)
        {
            _departmentService = departmentService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentsAsync()
        {
            var cachedDepartments = await _cacheService.GetData<IEnumerable<GetDepartmentDto>>("departments");

            if (cachedDepartments is null)
            {
                var expiryTime = DateTimeOffset.Now.AddSeconds(30);

                var departments = await _departmentService.GetDepartmentsAsync();
                await _cacheService.SetData<IEnumerable<GetDepartmentDto>>("departments", departments, expiryTime);

                return Ok(departments);
            }   
            
            return Ok(cachedDepartments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromRoute] Guid id)
        {
            var cachedDepartments = await _cacheService.GetData<IEnumerable<GetDepartmentDto>>("departments");
            
            if (cachedDepartments is null)
            {
                var department = await _departmentService.GetDepatmentByIdAsync(id);

                return Ok(department);
            }

            return Ok(cachedDepartments.Where(d => d.Id == id).FirstOrDefault());
        }
    }
}