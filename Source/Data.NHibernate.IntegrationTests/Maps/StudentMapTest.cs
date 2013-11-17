namespace Data.NHibernate.IntegrationTests.Maps
{
    using Builder;

    using Domain;

    using NHibernate.Repositories;

    using NUnit.Framework;

    using Utils;

    [TestFixture]
    public class StudentMapTest : BaseTestFixture
    {
        private IBaseRepository<Student> studentRepository;

        [SetUp]
        public void SetUp()
        {
            this.studentRepository = new BaseRepository<Student>();
        }

        [Test]
        public void ShouldSaveAndFetchStudent()
        {
            var student = new StudentBuilder().Build();
            this.studentRepository.SaveOrUpdate(student);
            this.FlushAndClearSession();

            var studentRetrieved = this.studentRepository.GetById(student.Id);

            Assert.IsNotNull(studentRetrieved);
            Assert.That(studentRetrieved.Id, Is.Not.EqualTo(0));
        }
    }
}