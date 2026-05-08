using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;
using HMS.Entity.Models.ResponseModels;

namespace HMS.Bussiness.Services.ServiceInterface
{
    public interface IPatientService
    {
        Task<GenericApiResponse<List<PatientResponseDTO>>> GetAllPatientsAsync();

        Task<GenericApiResponse<PatientResponseDTO>> GetPatientByIdAsync(int id);

        Task<GenericApiResponse<PatientResponseDTO>> CreatePatientAsync(PatientRequestDTO patientRequest);

        Task<GenericApiResponse<string>> UpdatePatientAsync(int id, PatientRequestDTO patientRequest);

        Task<GenericApiResponse<string>> DeletePatientAsync(int id);
    }
}
