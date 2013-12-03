using Domain;

using NUnit.Framework;

using Services.Mapper;
using Services.Models;

namespace Services.UnitTests.Mapper
{
    [TestFixture]
    public class DomainViewModelMapperTest
    {
        [Test]
        public void ShouldMapDomainToViewModel()
        {
            const int Id = 1;
            const int Value = 100;
            const string Name = "Name";
            var domainStub = new DomainStub { Id = Id, Name1 = Name, Value1 = Value };

            var viewModelStub = DomainViewModelMapper<DomainStub, ViewModelStub>.Map(domainStub);

            Assert.That(viewModelStub.Id, Is.EqualTo(Id));
            Assert.That(viewModelStub.Name1, Is.EqualTo(Name));
            Assert.That(viewModelStub.Value1, Is.EqualTo(Value));
        }

        [Test]
        public void ShouldMapViewModelToDomain()
        {
            const int Id = 1;
            const int Value = 100;
            const string Name = "Name";
            var viewModelStub = new ViewModelStub { Id = Id, Name1 = Name, Value1 = Value };

            var domainStub = DomainViewModelMapper<DomainStub, ViewModelStub>.Map(viewModelStub);

            Assert.That(domainStub.Id, Is.EqualTo(Id));
            Assert.That(domainStub.Name1, Is.EqualTo(Name));
            Assert.That(domainStub.Value1, Is.EqualTo(Value));
        }

        private class DomainStub : Entity
        {
            public int Value1 { get; set; }

            public string Name1 { get; set; }
        }

        private class ViewModelStub : ViewModel
        {
            public int Value1 { get; set; }

            public string Name1 { get; set; }
        }
    }
}