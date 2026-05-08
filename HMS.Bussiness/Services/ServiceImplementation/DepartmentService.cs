using AutoMapper;
using HMS.Bussiness.Services.ServiceInterface;
using HMS.Data.Models;
using HMS.Data.Repos.IRepo;
using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;
using HMS.Entity.Models.ResponseModels;

namespace HMS.Bussiness.Services.ServiceImplementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepo departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<DepartmentResponseDTO>> CreateDepartmentAsync(DepartmentRequestDTO departmentRequest)
        {
            var department = _mapper.Map<Department>(departmentRequest);
            var result = await _departmentRepo.AddAsync(department);

            return new GenericApiResponse<DepartmentResponseDTO>().SuccessResponseForPost(
                _mapper.Map<DepartmentResponseDTO>(result));
        }

        public async Task<GenericApiResponse<List<DepartmentResponseDTO>>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepo.GetAllAsync();

            return new GenericApiResponse<List<DepartmentResponseDTO>>().SuccessResponse(
                _mapper.Map<List<DepartmentResponseDTO>>(departments));
        }

        public async Task<GenericApiResponse<DepartmentResponseDTO>> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);

            if (department is null)
            {
                return new GenericApiResponse<DepartmentResponseDTO>().ErrorResponse("Department not found.");
            }

            return new GenericApiResponse<DepartmentResponseDTO>().SuccessResponse(
                _mapper.Map<DepartmentResponseDTO>(department));
        }

        public async Task<GenericApiResponse<string>> UpdateDepartmentAsync(int id, DepartmentRequestDTO departmentRequest)
        {
            var department = await _departmentRepo.GetByIdAsync(id);

            if (department is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Department not found.");
            }

            _mapper.Map(departmentRequest, department);
            await _departmentRepo.UpdateAsync(department);

            return new GenericApiResponse<string>().SuccessResponse("Department updated successfully.");
        }

        public async Task<GenericApiResponse<string>> DeleteDepartmentAsync(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);

            if (department is null)
            {
                return new GenericApiResponse<string>().ErrorResponse("Department not found.");
            }

            await _departmentRepo.DeleteAsync(department);

            return new GenericApiResponse<string>().SuccessResponse("Department deleted successfully.");
        }
    }
}
