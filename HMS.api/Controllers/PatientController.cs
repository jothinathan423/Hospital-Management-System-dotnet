using HMS.Bussiness.Service.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IpatientService _patientService;

        public PatientController(IpatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await _patientService.GetAllPatientsAsync();
            return StatusCode(response.StatusCode, response);
        }
    }
}
