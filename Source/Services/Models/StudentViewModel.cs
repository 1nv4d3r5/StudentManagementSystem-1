using System;

namespace Services.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string RollNumber { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}