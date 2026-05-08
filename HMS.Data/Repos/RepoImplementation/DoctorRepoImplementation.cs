using HMS.Data.Database;
using HMS.Data.Models;
using HMS.Data.Repos.IRepo;

namespace HMS.Data.Repos.RepoImplementation
{
    public class DoctorRepoImplementation : GenericRepoImplementation<Doctor>, IDoctorRepo
    {
        public DoctorRepoImplementation(HmsContext context) : base(context)
        {
        }
    }
}
