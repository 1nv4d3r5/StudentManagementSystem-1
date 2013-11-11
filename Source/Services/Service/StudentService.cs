using System.Collections.Generic;
using System.Linq;

using Data.NHibernate.Repositories;

using Domain;

using Omu.ValueInjecter;

using Services.Models;

namespace Services.Service
{
    public class StudentService
    {
        private readonly BaseRepository<Student> studentRepository;

        public StudentService(BaseRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public List<StudentViewModel> GetAllStudents()
        {
            var students = studentRepository.GetAll();
            return students.Select(x => new StudentViewModel().InjectFrom(x)).Cast<StudentViewModel>().ToList();
        }
    }
}