using HMS.Bussiness.Infrastructure;
using HMS.Bussiness.Services.ServiceImplementation;
using HMS.Bussiness.Services.ServiceInterface;
using HMS.Data.Repos.IRepo;
using HMS.Data.Repos.RepoImplementation;

namespace HMS.api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepo, PatientRepoImplementation>();
            services.AddScoped<IDepartmentRepo, DepartmentRepoImplementation>();
            services.AddScoped<IDoctorRepo, DoctorRepoImplementation>();

            services.AddAutoMapper(cfg => { cfg.AddProfile(typeof(PatientMapper)); });

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDoctorService, DoctorService>();
        }
    }
}
