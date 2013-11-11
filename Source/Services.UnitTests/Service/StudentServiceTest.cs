using System.Collections.Generic;
using System.Linq;

using Data.NHibernate.Repositories;

using Domain;

using Moq;

using NUnit.Framework;

using Services.Service;

namespace Services.UnitTests.Service
{
    [TestFixture]
    public class StudentServiceTest
    {
        private StudentService studentService;

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

            var students = this.studentService.GetAllStudents();

            Assert.That(students, Is.Not.Null);
            Assert.That(students.Count, Is.EqualTo(1));
            Assert.That(students.Select(x => x.Id), Is.EqualTo(studentsFromDb.Select(x => x.Id)));
        }

        [Test]
        public void ShouldMapDomainToViewModel()
        {
            const int Id = 1;
            const string FirstName = "FirstName";
            const string LastName = "LastName";
            const string RollNumber = "RollNumber";
            var studentsFromDb = new List<Student> { new Student { Id = Id, FirstName = FirstName, LastName = LastName, RollNumber = RollNumber } };

            this.mockStudentRepository.Setup(repository => repository.GetAll()).Returns(studentsFromDb);

            var students = this.studentService.GetAllStudents();

            Assert.That(students, Is.Not.Null);
            Assert.That(students.Count, Is.EqualTo(1));
            var studentViewModel = students.First();
            Assert.That(studentViewModel.Id, Is.EqualTo(Id));
            Assert.That(studentViewModel.FirstName, Is.EqualTo(FirstName));
            Assert.That(studentViewModel.LastName, Is.EqualTo(LastName));
            Assert.That(studentViewModel.RollNumber, Is.EqualTo(RollNumber));
        }
    }
}