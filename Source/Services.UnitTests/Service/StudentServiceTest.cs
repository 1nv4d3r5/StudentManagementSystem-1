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
    public class StudentServiceTest
    {
        private IStudentService studentService;

        private Mock<BaseRepository<Student>> mockStudentRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockStudentRepository = new Mock<BaseRepository<Student>>();
            this.studentService = new StudentService(this.mockStudentRepository.Object);
        }

        [Test]
        public void ShouldGetAllStudents()
        {
            var studentsFromDb = new List<Student> { new Student { Id = 1 } };
            this.mockStudentRepository.Setup(repository => repository.GetAll()).Returns(studentsFromDb);

            var students = this.studentService.GetAll();

            Assert.That(students, Is.Not.Null);
            Assert.That(students.Count, Is.EqualTo(1));
            Assert.That(students.Select(x => x.Id), Is.EqualTo(studentsFromDb.Select(x => x.Id)));
        }
    }
}