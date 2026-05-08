using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;
using HMS.Entity.Models.ResponseModels;

namespace HMS.Bussiness.Services.ServiceInterface
{
    public interface IDepartmentService
    {
        Task<GenericApiResponse<List<DepartmentResponseDTO>>> GetAllDepartmentsAsync();

        Task<GenericApiResponse<DepartmentResponseDTO>> GetDepartmentByIdAsync(int id);

        Task<GenericApiResponse<DepartmentResponseDTO>> CreateDepartmentAsync(DepartmentRequestDTO departmentRequest);

        Task<GenericApiResponse<string>> UpdateDepartmentAsync(int id, DepartmentRequestDTO departmentRequest);

        Task<GenericApiResponse<string>> DeleteDepartmentAsync(int id);
    }
}
