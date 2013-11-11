using System.Collections.Generic;

using Data.NHibernate.Repositories;

using Domain;

using Moq;

using NUnit.Framework;

using Services.Service;

namespace Services.UnitTests
{
    [TestFixture]
    public class StudentServiceTest
    {
        private StudentService studentService;

        private Mock<BaseRepository<Student>> mockStudentRepository;

        [SetUp]
        public void SetUp()
        {
            mockStudentRepository = new Mock<BaseRepository<Student>>();
            studentService = new StudentService(mockStudentRepository.Object);
        }

        [Test]
        public void ShouldGetAllStudents()
        {
            var studentsFromDb = new List<Student> { new Student { Id = 1 } };
            mockStudentRepository.Setup(repository => repository.GetAll()).Returns(studentsFromDb);

            var students = studentService.GetAllStudents();

            Assert.That(students, Is.Not.Null);
            Assert.That(students, Is.EqualTo(studentsFromDb));
        }
    }
}
