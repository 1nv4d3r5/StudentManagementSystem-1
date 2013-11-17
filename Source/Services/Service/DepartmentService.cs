using System.Collections.Generic;
using System.Linq;

using Domain;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
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