namespace Data.NHibernate.Repositories
{
    using System.Linq;

    using Domain;

    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public Department GetByCode(string departmentCode)
        {
            var department =
                GetSession()
                    .QueryOver<Department>()
                    .Where(x => x.Code == departmentCode)
                    .List<Department>()
                    .FirstOrDefault();
            return department;
        }
    }
}