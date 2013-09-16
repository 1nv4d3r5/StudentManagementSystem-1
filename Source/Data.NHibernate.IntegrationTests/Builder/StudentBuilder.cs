namespace Data.NHibernate.IntegrationTests.Builder
{
    using System;

    using Domain;

    public class StudentBuilder
    {
        public StudentBuilder()
        {
            this.RollNumber = string.Format("R{0}", new Random().Next(int.MaxValue));
            this.FirstName = "FirstName";
            this.LastName = "LastName";
        }

        public StudentBuilder(string rollNumber, string firstName, string lastName)
        {
            this.RollNumber = rollNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string RollNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Student Build()
        {
            var student = new Student
                              {
                                  RollNumber = this.RollNumber,
                                  FirstName = this.FirstName,
                                  LastName = this.LastName
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