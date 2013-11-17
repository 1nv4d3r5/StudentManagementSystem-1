using System.Collections.Generic;
using System.Linq;

using Data.NHibernate.Repositories;

using Domain;

using Moq;

using NUnit.Framework;

using Services.Contracts;
using Services.Service;

namespace Services.UnitTests.Service
{
    [TestFixture]
    public class DepartmentServiceTest
    {
        private IDepartmentService departmentService;

        private Mock<DepartmentRepository> mockDepartmentRepository;

        [SetUp]
        public void SetUp()
        {
            mockDepartmentRepository = new Mock<DepartmentRepository>();
            departmentService = new DepartmentService(mockDepartmentRepository.Object);
        }

        [Test]
        public void ShouldGetAllDepartments()
        {
            var departmentsFromDb = new List<Department> { new Department { Id = 1 } };
            mockDepartmentRepository.Setup(repository => repository.GetAll()).Returns(departmentsFromDb);

            var departments = this.departmentService.GetAll();

            Assert.That(departments, Is.Not.Null);
            Assert.That(departments.Count, Is.EqualTo(1));
            Assert.That(departments.Select(x => x.Id), Is.EqualTo(departmentsFromDb.Select(x => x.Id)));
        }
    }
}