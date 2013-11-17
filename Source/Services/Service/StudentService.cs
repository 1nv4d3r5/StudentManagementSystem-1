using System.Collections.Generic;
using System.Linq;

using Domain;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IBaseRepository<Student> studentRepository;

        public StudentService(IBaseRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public List<StudentViewModel> GetAll()
        {
            var students = studentRepository.GetAll();
            return students.Select(DomainViewModelMapper.Map<StudentViewModel>).ToList();
        }
    }
}