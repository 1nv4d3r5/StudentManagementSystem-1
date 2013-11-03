using System;

using Data.NHibernate.Repositories;

using Domain;

namespace TestView
{
    public class DepartmentView
    {
        private readonly BaseRepository<Department> departmentRepository = new BaseRepository<Department>();

        public void ShouldGetAllDepartments()
        {
            Console.WriteLine("Populating Department Information");
            var departments = this.departmentRepository.GetAll();
            foreach (var department in departments)
            {
                Console.WriteLine();
                Console.WriteLine("Department Code \t {0}", department.Code);
                Console.WriteLine("Department Name \t {0}", department.Name);
            }
        }
    }
}