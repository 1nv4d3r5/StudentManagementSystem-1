using Domain;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class DepartmentService : Service<Department, DepartmentViewModel>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository repository)
            : base(repository)
        {
        }
    }
}