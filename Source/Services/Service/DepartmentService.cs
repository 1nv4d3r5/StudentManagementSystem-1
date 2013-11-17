using System.Collections.Generic;
using System.Linq;

using Data.NHibernate.Repositories;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository departmentRepository;

        public DepartmentService(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public List<DepartmentViewModel> GetAll()
        {
            var departments = departmentRepository.GetAll();
            return departments.Select(DomainViewModelMapper.Map<DepartmentViewModel>).ToList();
        }
    }
}