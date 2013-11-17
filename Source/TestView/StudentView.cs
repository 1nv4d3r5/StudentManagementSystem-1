using System;

using Services.Contracts;
using Services.Service;

namespace TestView
{
    public class StudentView : IStudentView
    {
        private readonly IStudentService studentService;

        public StudentView(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public void ShouldGetAllStudents()
        {
            Console.WriteLine("Populating Students Records");

            var students = studentService.GetAll();
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

    public interface IStudentView
    {
    }
}