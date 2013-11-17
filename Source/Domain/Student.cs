namespace Domain
{
    using System;

    public class Student : Entity
    {
        public virtual string RollNumber { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime JoinDate { get; set; }

        public virtual Department Department { get; set; }
    }
}