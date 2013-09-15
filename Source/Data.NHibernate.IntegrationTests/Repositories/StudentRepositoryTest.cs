namespace Data.NHibernate.IntegrationTests.Repositories
{
    using System;

    using Domain;

    using NHibernate.Repositories;

    using NUnit.Framework;

    using Utils;

    [TestFixture]
    public class StudentRepositoryTest : BaseTestFixture
    {
        private BaseRepository<Student> studentRepository;

        [SetUp]
        public void SetUp()
        {
            this.studentRepository = new BaseRepository<Student>();
        }

        [Test]
        public void ShouldGetStudentById()
        {
            var student = studentRepository.GetById(1);
            Console.WriteLine();
            Console.WriteLine("RollNumber \t {0}", student.RollNumber);
            Console.WriteLine("FirstName \t {0}", student.FirstName);
            Console.WriteLine("MiddleName \t {0}", student.MiddleName);
            Console.WriteLine("LastName \t {0}", student.LastName);
            Console.WriteLine("JoinDate \t {0}", student.JoinDate);
        }

        [Test]
        public void ShouldGetAllStudents()
        {
            var students = studentRepository.GetAll();
            Assert.That(students.Count, Is.EqualTo(6));
            foreach (var student in students)
            {
                Console.WriteLine();
                Console.WriteLine("RollNumber \t {0}", student.RollNumber);
                Console.WriteLine("FirstName \t {0}", student.FirstName);
                Console.WriteLine("MiddleName \t {0}", student.MiddleName);
                Console.WriteLine("LastName \t {0}", student.LastName);
                Console.WriteLine("JoinDate \t {0}", student.JoinDate);
            }
        }

        [Test]
        public void ShouldSaveAndUpdateStudent()
        {
            var student = new Student { FirstName = "A", LastName = "C", RollNumber = "12345", JoinDate = DateTime.Now };
            studentRepository.SaveOrUpdate(student);
            FlushAndClearSession();

            var studentRetrievedAfterAdd = studentRepository.GetById(student.Id);

            Assert.IsNotNull(studentRetrievedAfterAdd);
            Assert.That(studentRetrievedAfterAdd.Id, Is.Not.EqualTo(0));


            const string MiddleName = "B";
            studentRetrievedAfterAdd.MiddleName = MiddleName;
            studentRepository.SaveOrUpdate(studentRetrievedAfterAdd);
            FlushAndClearSession();

            var studentRetrievedAfterUpdate = studentRepository.GetById(student.Id);

            Assert.IsNotNull(studentRetrievedAfterUpdate);
            Assert.That(studentRetrievedAfterUpdate.Id, Is.EqualTo(studentRetrievedAfterAdd.Id));
            Assert.That(studentRetrievedAfterUpdate.MiddleName, Is.EqualTo(MiddleName));
        }

        [Test]
        public void ShouldAddCommitAndDeleteStudent()
        {
            var student = new Student { FirstName = "A", LastName = "C", RollNumber = "12345", JoinDate = DateTime.Now };
            studentRepository.SaveOrUpdate(student);
            studentRepository.CommitAndCloseSession();

            studentRepository.Delete(student);
            studentRepository.CommitAndCloseSession();

            var studentRetrievedAfterDelete = studentRepository.GetById(student.Id);
            Assert.IsNull(studentRetrievedAfterDelete);
        }
    }
}