using AutoMapper;
using HMS.Bussiness.Services.ServiceInterface;
using HMS.Data.Models;
using HMS.Data.Repos.IRepo;
using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;
using HMS.Entity.Models.ResponseModels;

namespace HMS.Bussiness.Services.ServiceImplementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepo patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<PatientResponseDTO>> CreatePatientAsync(PatientRequestDTO patientRequest)
        {
            var patient = _mapper.Map<Patient>(patientRequest);
            var result = await _patientRepo.AddAsync(patient);

            return new GenericApiResponse<PatientResponseDTO>().SuccessResponseForPost(
                _mapper.Map<PatientResponseDTO>(result));
        }

        public async Task<GenericApiResponse<List<PatientResponseDTO>>> GetAllPatientsAsync()
        {
            var patients = await _patientRepo.GetAllAsync();

            return new GenericApiResponse<List<PatientResponseDTO>>().SuccessResponse(
                _mapper.Map<List<PatientResponseDTO>>(patients));
        }

        public async Task<GenericApiResponse<PatientResponseDTO>> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient is null)
            {
                return new GenericApiResponse<PatientResponseDTO>().ErrorResponse("Patient not found.");
            }

            return new GenericApiResponse<PatientResponseDTO>().SuccessResponse(
                _mapper.Map<PatientResponseDTO>(patient));
        }

        public async Task<GenericApiResponse<string>> UpdatePatientAsync(int id, PatientRequestDTO patientRequest)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Patient not found.");
            }

            _mapper.Map(patientRequest, patient);
            await _patientRepo.UpdateAsync(patient);

            return new GenericApiResponse<string>().SuccessResponse("Patient updated successfully.");
        }

        public async Task<GenericApiResponse<string>> DeletePatientAsync(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Patient not found.");
            }

            await _patientRepo.DeleteAsync(patient);

            return new GenericApiResponse<string>().SuccessResponse("Patient deleted successfully.");
        }
    }
}
