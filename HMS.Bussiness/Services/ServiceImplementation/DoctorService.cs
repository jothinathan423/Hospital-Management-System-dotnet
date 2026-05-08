using AutoMapper;
using HMS.Bussiness.Services.ServiceInterface;
using HMS.Data.Models;
using HMS.Data.Repos.IRepo;
using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;
using HMS.Entity.Models.ResponseModels;

namespace HMS.Bussiness.Services.ServiceImplementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepo doctorRepo, IDepartmentRepo departmentRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<DoctorResponseDTO>> CreateDoctorAsync(DoctorRequestDTO doctorRequest)
        {
            var department = await _departmentRepo.GetByIdAsync(doctorRequest.DepartmentId);

            if (department is null)
            {
                return new GenericApiResponse<DoctorResponseDTO>().ErrorResponse("Department not found.");
            }

            var doctor = _mapper.Map<Doctor>(doctorRequest);
            var result = await _doctorRepo.AddAsync(doctor);

            return new GenericApiResponse<DoctorResponseDTO>().SuccessResponseForPost(
                _mapper.Map<DoctorResponseDTO>(result));
        }

        public async Task<GenericApiResponse<List<DoctorResponseDTO>>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepo.GetAllAsync();

            return new GenericApiResponse<List<DoctorResponseDTO>>().SuccessResponse(
                _mapper.Map<List<DoctorResponseDTO>>(doctors));
        }

        public async Task<GenericApiResponse<DoctorResponseDTO>> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);

            if (doctor is null)
            {
                return new GenericApiResponse<DoctorResponseDTO>().ErrorResponse("Doctor not found.");
            }

            return new GenericApiResponse<DoctorResponseDTO>().SuccessResponse(
                _mapper.Map<DoctorResponseDTO>(doctor));
        }

        public async Task<GenericApiResponse<string>> UpdateDoctorAsync(int id, DoctorRequestDTO doctorRequest)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);

            if (doctor is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Doctor not found.");
            }

            var department = await _departmentRepo.GetByIdAsync(doctorRequest.DepartmentId);

            if (department is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Department not found.");
            }

            _mapper.Map(doctorRequest, doctor);
            await _doctorRepo.UpdateAsync(doctor);

            return new GenericApiResponse<string>().SuccessResponse("Doctor updated successfully.");
        }

        public async Task<GenericApiResponse<string>> DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);

            if (doctor is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Doctor not found.");
            }

            await _doctorRepo.DeleteAsync(doctor);

            return new GenericApiResponse<string>().SuccessResponse("Doctor deleted successfully.");
        }
    }
}
