using System.Collections.Generic;

using Domain;

using Services.Contracts;
using Services.Mapper;
using Services.Models;

namespace Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IBaseRepository<Student> repository;

        public StudentService(IBaseRepository<Student> repository)
        {
            this.repository = repository;
        }

        public List<StudentViewModel> GetAll()
        {
            return DomainViewModelMapper<Student, StudentViewModel>.Map(this.repository.GetAll());
        }
    }
}