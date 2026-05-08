using HMS.Data.Database;
using HMS.Data.Models;
using HMS.Data.Repos.IRepo;

namespace HMS.Data.Repos.RepoImplementation
{
    public class DepartmentRepoImplementation : GenericRepoImplementation<Department>, IDepartmentRepo
    {
        public DepartmentRepoImplementation(HmsContext context) : base(context)
        {
        }
    }
}
