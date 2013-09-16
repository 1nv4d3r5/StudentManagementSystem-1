namespace Data.NHibernate.IntegrationTests.Repositories
{
    using System.Data.SqlClient;

    using Builder;

    using NHibernate.Repositories;

    using NUnit.Framework;

    using Utils;

    [TestFixture]
    public class DepartmentRepositoryTest : BaseTestFixture
    {
        private DepartmentRepository departmentRepository;

        [SetUp]
        public void SetUp()
        {
            departmentRepository = new DepartmentRepository();
        }

        [Test]
        public void ShouldGetAllDepartments()
        {
            var departments = departmentRepository.GetAll();
            Assert.That(departments.Count, Is.EqualTo(6));
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

        [Test]
        public void ShouldGetDepartmentByCode()
        {
            const string DepartmentCode = "DD1";
            var department = new DepartmentBuilder().WithDepartmentCode(DepartmentCode).Build();
            departmentRepository.SaveOrUpdate(department);
            FlushAndClearSession();

            var departmentRetrieved = departmentRepository.GetByCode(DepartmentCode);

            Assert.IsNotNull(departmentRetrieved);
            Assert.That(department.Id, Is.EqualTo(departmentRetrieved.Id));
        }

        [Test]
        public void ShouldReturnNullWhenDepartmentCodeIsWrong()
        {
            const string DepartmentCode = "Some Code";

            var departmentRetrieved = departmentRepository.GetByCode(DepartmentCode);

            Assert.IsNull(departmentRetrieved);
        }
    }
}