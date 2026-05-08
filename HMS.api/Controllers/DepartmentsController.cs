using HMS.Bussiness.Services.ServiceInterface;
using HMS.Entity.Models.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace HMS.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var result = await _departmentService.GetAllDepartmentsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await _departmentService.GetDepartmentByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentRequestDTO departmentRequest)
        {
            var result = await _departmentService.CreateDepartmentAsync(departmentRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentRequestDTO departmentRequest)
        {
            var result = await _departmentService.UpdateDepartmentAsync(id, departmentRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
