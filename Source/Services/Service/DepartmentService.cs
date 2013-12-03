using System.Collections.Generic;

using Domain;

using Services.Contracts;
using Services.Mapper;
using Services.Models;

namespace Services.Service
{
    public class DepartmentService  :IDepartmentService
    {
        private readonly IDepartmentRepository repository;

        public DepartmentService(IDepartmentRepository repository)

        {
            this.repository = repository;
        }

        public List<DepartmentViewModel> GetAll()
        {
            return DomainViewModelMapper<Department,DepartmentViewModel>.Map(repository.GetAll());
        }
    }
}