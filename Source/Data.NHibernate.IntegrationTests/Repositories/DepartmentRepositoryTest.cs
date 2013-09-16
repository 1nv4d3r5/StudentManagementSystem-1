namespace Data.NHibernate.IntegrationTests.Repositories
{
    using System.Data.SqlClient;

    using Builder;

    using Domain;

    using NHibernate.Repositories;

    using NUnit.Framework;

    using Utils;

    [TestFixture]
    public class DepartmentRepositoryTest : BaseTestFixture
    {
        private BaseRepository<Department> departmentRepository;

        [SetUp]
        public void SetUp()
        {
            departmentRepository = new BaseRepository<Department>();
        }

        [Test]
        public void ShouldGetAllDepartments()
        {
            var departments = departmentRepository.GetAll();
            Assert.That(departments.Count, Is.EqualTo(6));
        }

        [Test]
        public void ShouldSaveAndFetchDepartment()
        {
            var department = new DepartmentBuilder().Build();
            departmentRepository.SaveOrUpdate(department);
            FlushAndClearSession();

            var departmentRetrieved = departmentRepository.GetById(department.Id);

            Assert.IsNotNull(departmentRetrieved);
            Assert.That(departmentRetrieved.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldCheckUniqueConstaintOfRollNumber()
        {
            var department1 = new DepartmentBuilder().WithDepartmentCode("DD1").Build();
            departmentRepository.SaveOrUpdate(department1);
            FlushAndClearSession();

            var department2 = new DepartmentBuilder().WithDepartmentCode("DD1").Build();

            var exception = Assert.Catch(() => this.departmentRepository.SaveOrUpdate(department2));
            Assert.That(exception.InnerException.GetType(), Is.EqualTo(typeof(SqlException)));
            Assert.That(exception.InnerException.Message.Contains("Violation of UNIQUE KEY constraint"));
        }
    }
}