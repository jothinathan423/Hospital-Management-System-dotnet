using HMS.Data.Model;
using HMS.Entity.GenericResponse;

namespace HMS.Bussiness.Service.ServiceInterface
{
    public interface IpatientService
    {
        Task<GenericResponse<List<Patient>>> GetAllPatientsAsync();
    }
}
