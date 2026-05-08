using AutoMapper;
using HMS.Data.Models;
using HMS.Entity.Models.RequestDTO;
using HMS.Entity.Models.ResponseDTO;

namespace HMS.Bussiness.Infrastructure
{
    public class PatientMapper : Profile
    {
        public PatientMapper()
        {
            CreateMap<PatientRequestDTO, Patient>();
            CreateMap<Patient, PatientResponseDTO>();

            CreateMap<DepartmentRequestDTO, Department>();
            CreateMap<Department, DepartmentResponseDTO>();

            CreateMap<DoctorRequestDTO, Doctor>();
            CreateMap<Doctor, DoctorResponseDTO>();
        }
    }
}
