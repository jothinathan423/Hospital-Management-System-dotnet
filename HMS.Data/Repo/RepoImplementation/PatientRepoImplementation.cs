using HMS.Data.Database;
using HMS.Data.Model;
using HMS.Data.Repo.IRepo;

namespace HMS.Data.Repo.RepoImplementation
{
    public class PatientRepoImplementation : GenericRepoImplementation<Patient>, IPatientRepo
    {
        public PatientRepoImplementation(HmsContext context) : base(context)
        {
        }
    }
}
