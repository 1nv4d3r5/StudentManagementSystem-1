namespace Data.NHibernate.IntegrationTests.Repositories
{
    using System;

    using NHibernate.Repositories;

    using NUnit.Framework;

    [TestFixture]
    public class StudentRepositoryTest
    {
        [Test]
        public void ShouldGetStudentById()
        {
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(1);
            Console.WriteLine();
            Console.WriteLine("RollNumber \t {0}", student.RollNumber);
            Console.WriteLine("FirstName \t {0}", student.FirstName);
            Console.WriteLine("MiddleName \t {0}", student.MiddleName);
            Console.WriteLine("LastName \t {0}", student.LastName);
            Console.WriteLine("JoinDate \t {0}", student.JoinDate);
        }
    }
}