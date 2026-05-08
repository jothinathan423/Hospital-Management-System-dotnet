using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;
using HMS.Entity.Models.ResponseModels;

namespace HMS.Bussiness.Services.ServiceInterface
{
    public interface IDoctorService
    {
        Task<GenericApiResponse<List<DoctorResponseDTO>>> GetAllDoctorsAsync();

        Task<GenericApiResponse<DoctorResponseDTO>> GetDoctorByIdAsync(int id);

        Task<GenericApiResponse<DoctorResponseDTO>> CreateDoctorAsync(DoctorRequestDTO doctorRequest);

        Task<GenericApiResponse<string>> UpdateDoctorAsync(int id, DoctorRequestDTO doctorRequest);

        Task<GenericApiResponse<string>> DeleteDoctorAsync(int id);
    }
}
