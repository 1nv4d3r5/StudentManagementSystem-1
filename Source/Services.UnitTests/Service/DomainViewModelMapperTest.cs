using Domain;

using NUnit.Framework;

using Services.Models;
using Services.Service;

namespace Services.UnitTests.Service
{
    [TestFixture]
    public class DomainViewModelMapperTest
    {
        [Test]
        public void ShouldMapDomainToViewModel()
        {
            const int Id = 1;
            const string FirstName = "FirstName";
            const string LastName = "LastName";
            const string RollNumber = "RollNumber";
            var student = new Student { Id = Id, FirstName = FirstName, LastName = LastName, RollNumber = RollNumber };

            var studentViewModel = DomainViewModelMapper.Map<StudentViewModel>(student);

            Assert.That(studentViewModel.Id, Is.EqualTo(Id));
            Assert.That(studentViewModel.FirstName, Is.EqualTo(FirstName));
            Assert.That(studentViewModel.LastName, Is.EqualTo(LastName));
            Assert.That(studentViewModel.RollNumber, Is.EqualTo(RollNumber));
        }
    }
}