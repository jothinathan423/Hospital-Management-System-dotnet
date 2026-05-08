using HMS.Data.Database;
using HMS.Data.Models;
using HMS.Data.Repos.IRepo;

namespace HMS.Data.Repos.RepoImplementation
{
    public class PatientRepoImplementation : GenericRepoImplementation<Patient>, IPatientRepo
    {
        public PatientRepoImplementation(HmsContext context) : base(context)
        {
        }
    }
}
