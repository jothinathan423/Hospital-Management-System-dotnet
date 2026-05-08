using HMS.Bussiness.Services.ServiceInterface;
using HMS.Entity.Models.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace HMS.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _doctorService.GetAllDoctorsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var result = await _doctorService.GetDoctorByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorRequestDTO doctorRequest)
        {
            var result = await _doctorService.CreateDoctorAsync(doctorRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorRequestDTO doctorRequest)
        {
            var result = await _doctorService.UpdateDoctorAsync(id, doctorRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.DeleteDoctorAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
