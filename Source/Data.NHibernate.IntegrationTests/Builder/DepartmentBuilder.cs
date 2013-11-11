namespace Data.NHibernate.IntegrationTests.Builder
{
    using System;

    using Domain;

    public class DepartmentBuilder
    {
        private string Code { get; set; }

        private string Name { get; set; }

        public DepartmentBuilder()
        {
            this.Code = string.Format("C{0}", new Random().Next(1000));
            this.Name = string.Format("Department{0}", new Random().Next(int.MaxValue));
        }

        public Department Build()
        {
            var department = new Department { Code = this.Code, Name = this.Name, };
            return department;
        }

        public DepartmentBuilder WithDepartmentCode(string departmentCode)
        {
            this.Code = departmentCode;
            return this;
        }
    }
}