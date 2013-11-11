using System.Collections.Generic;

using Data.NHibernate.Repositories;

using Domain;

namespace Services.Service
{
    public class StudentService
    {
        private readonly BaseRepository<Student> studentRepository;

        public StudentService(BaseRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return studentRepository.GetAll();
        }
    }
}