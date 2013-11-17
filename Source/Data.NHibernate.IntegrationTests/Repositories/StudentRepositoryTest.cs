namespace Data.NHibernate.IntegrationTests.Repositories
{
    using System;
    using System.Data.SqlClient;

    using Builder;

    using Domain;

    using NHibernate.Repositories;

    using NUnit.Framework;

    using Utils;

    [TestFixture]
    public class StudentRepositoryTest : BaseTestFixture
    {
        private IBaseRepository<Student> studentRepository;

        [SetUp]
        public void SetUp()
        {
            this.studentRepository = new BaseRepository<Student>();
        }

        [Test]
        public void ShouldGetAllStudents()
        {
            var students = studentRepository.GetAll();
            Assert.That(students.Count, Is.EqualTo(6));
        }

        [Test]
        public void ShouldGenerateJoinDateByDefault()
        {
            var student = new StudentBuilder().Build();
            studentRepository.SaveOrUpdate(student);
            FlushAndClearSession();

            var studentRetrievedRetrieved = studentRepository.GetById(student.Id);

            Assert.IsNotNull(studentRetrievedRetrieved);
            Assert.That(studentRetrievedRetrieved.JoinDate.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public void ShouldSaveFetchAndUpdateStudent()
        {
            var student = new StudentBuilder().Build();
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
            var student = new StudentBuilder().Build();
            studentRepository.SaveOrUpdate(student);
            studentRepository.CommitAndCloseSession();

            studentRepository.Delete(student);
            studentRepository.CommitAndCloseSession();

            var studentRetrievedAfterDelete = studentRepository.GetById(student.Id);
            Assert.IsNull(studentRetrievedAfterDelete);
        }

        [Test]
        public void ShouldCheckUniqueConstaintOfRollNumber()
        {
            var student1 = new StudentBuilder().WithRollNumber("12345").Build();
            studentRepository.SaveOrUpdate(student1);
            FlushAndClearSession();

            var student2 = new StudentBuilder().WithRollNumber("12345").Build();

            var exception = Assert.Catch(() => studentRepository.SaveOrUpdate(student2));
            Assert.That(exception.InnerException.GetType(), Is.EqualTo(typeof(SqlException)));
            Assert.That(exception.InnerException.Message.Contains("Violation of UNIQUE KEY constraint"));
        }
    }
}