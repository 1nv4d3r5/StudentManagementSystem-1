using System;

using Services.Contracts;

namespace TestView
{
    public class DepartmentView
    {
        private readonly IDepartmentService departmentService;

        public DepartmentView(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public void ShouldGetAllDepartments()
        {
            Console.WriteLine("Populating Department Information");
            var departments = departmentService.GetAll();
            foreach (var department in departments)
            {
                Console.WriteLine();
                Console.WriteLine("Department Code \t {0}", department.Code);
                Console.WriteLine("Department Name \t {0}", department.Name);
            }
        }
    }
}