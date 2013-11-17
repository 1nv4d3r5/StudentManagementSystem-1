using Domain;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class StudentService : Service<Student,StudentViewModel>,IStudentService
    {
        public StudentService(IBaseRepository<Student> repository)
            : base(repository)
        {
        }
    }
}