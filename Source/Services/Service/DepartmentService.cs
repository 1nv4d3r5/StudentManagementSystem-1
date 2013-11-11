using System.Collections.Generic;
using System.Linq;

using Data.NHibernate.Repositories;

using Omu.ValueInjecter;

using Services.Models;

namespace Services.Service
{
    public class DepartmentService
    {
        private readonly DepartmentRepository departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public List<DepartmentViewModel> GetAllDepartments()
        {
            var departments = departmentRepository.GetAll();
            return departments.Select(x => new DepartmentViewModel().InjectFrom(x)).Cast<DepartmentViewModel>().ToList();
        }
    }
}