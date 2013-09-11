namespace Domain
{
    using System;

    public class Student
    {
        public virtual int Id { get; set; }

        public virtual string RollNumber { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime JoinDate { get; set; }
    }
}