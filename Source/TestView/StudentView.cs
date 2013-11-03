using System;

using Data.NHibernate.Repositories;

using Domain;

namespace TestView
{
    public class StudentView
    {
        private readonly BaseRepository<Student> studentRepository = new BaseRepository<Student>();

        public void ShouldGetAllStudents()
        {
            Console.WriteLine("Populating Students Records");

            var students = this.studentRepository.GetAll();
            foreach (var student in students)
            {
                Console.WriteLine();
                Console.WriteLine("RollNumber \t {0}", student.RollNumber);
                Console.WriteLine("FirstName \t {0}", student.FirstName);
                Console.WriteLine("MiddleName \t {0}", student.MiddleName);
                Console.WriteLine("LastName \t {0}", student.LastName);
                Console.WriteLine("JoinDate \t {0}", student.JoinDate);
            }
        }
    }
}