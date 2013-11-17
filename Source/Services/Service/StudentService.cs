using System.Collections.Generic;
using System.Linq;

using Data.NHibernate.Repositories;

using Domain;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly BaseRepository<Student> studentRepository;

        public StudentService(BaseRepository<Student> studentRepository)
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