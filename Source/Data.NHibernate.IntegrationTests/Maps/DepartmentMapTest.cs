namespace Data.NHibernate.IntegrationTests.Maps
{
    using Builder;

    using Domain;

    using NHibernate.Repositories;

    using NUnit.Framework;

    using Utils;

    [TestFixture]
    public class DepartmentMapTest : BaseTestFixture
    {
        private BaseRepository<Department> departmentRepository;

        [SetUp]
        public void SetUp()
        {
            this.departmentRepository = new BaseRepository<Department>();
        }

        [Test]
        public void ShouldSaveAndFetchDepartment()
        {
            var department = new DepartmentBuilder().Build();
            this.departmentRepository.SaveOrUpdate(department);
            this.FlushAndClearSession();

            var departmentRetrieved = this.departmentRepository.GetById(department.Id);

            Assert.IsNotNull(departmentRetrieved);
            Assert.That(departmentRetrieved.Id, Is.Not.EqualTo(0));
        }
    }
}