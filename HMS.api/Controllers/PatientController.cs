using HMS.Bussiness.Services.ServiceInterface;
using HMS.Entity.Models.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace HMS.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _patientService.GetAllPatientsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _patientService.GetPatientByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientRequestDTO patientRequest)
        {
            var result = await _patientService.CreatePatientAsync(patientRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientRequestDTO patientRequest)
        {
            var result = await _patientService.UpdatePatientAsync(id, patientRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
