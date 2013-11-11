namespace Data.NHibernate.IntegrationTests.Builder
{
    using System;

    using Domain;

    using NHibernate.Repositories;

    public class StudentBuilder
    {
        private string RollNumber { get; set; }

        private string FirstName { get; set; }

        private string LastName { get; set; }

        private Department Department { get; set; }

        public StudentBuilder()
        {
            this.RollNumber = string.Format("R{0}", new Random().Next(int.MaxValue));
            this.FirstName = "FirstName";
            this.LastName = "LastName";
            var department = new DepartmentRepository().GetByCode("ECE");
            this.Department = department;
        }

        public Student Build()
        {
            var student = new Student
                              {
                                  RollNumber = this.RollNumber,
                                  FirstName = this.FirstName,
                                  LastName = this.LastName,
                                  Department = this.Department
                              };
            return student;
        }

        public StudentBuilder WithRollNumber(string rollNumber)
        {
            this.RollNumber = rollNumber;
            return this;
        }
    }
}