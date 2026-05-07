using HMS.Bussiness.Service.ServiceInterface;
using HMS.Data.Model;
using HMS.Data.Repo.IRepo;
using HMS.Entity.GenericResponse;

namespace HMS.Bussiness.Service.ServiceImplementation
{
    public class PatientService : IpatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<GenericResponse<List<Patient>>> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _patientRepo.GetAllAsync();
                return GenericResponse<List<Patient>>.Success(patients, "Patients fetched successfully.");
            }
            catch (Exception ex)
            {
                return GenericResponse<List<Patient>>.Failure(
                    "Unable to fetch patients.",
                    500,
                    new List<string> { ex.Message });
            }
        }
    }
}
