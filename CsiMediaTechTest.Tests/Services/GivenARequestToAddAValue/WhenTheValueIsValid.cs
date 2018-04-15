using CsiMediaTechTest.Services;
using NUnit.Framework;
using System.Linq;

namespace CsiMediaTechTest.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenTheValueIsValid
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            _subject = new ValuesService();
            _subject.AddValue(123);
        }

        [TestCase]
        public void ThenTheValueIsAddedToTheList()
        {
            Assert.That(_subject.GetValues().Contains(123));
        }

        [TestCase]
        public void ThenTheSortOrderIsSetToUnordered()
        {
            Assert.That(_subject.SortBy, Is.EqualTo(Models.SortByEnum.Unordered));
        }

        [TestCase]
        public void ThenThereIsOnlyOneItemInTheList()
        {
            Assert.That(_subject.GetValues().Count(), Is.EqualTo(1));
        }
    }
}
