using CsiMediaTechTest.Services;
using NUnit.Framework;
using System.Linq;

namespace CsiMediaTechTest.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenTheValueIsNotValid
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            _subject = new ValuesService();
            _subject.AddValue(123);
            _subject.AddValue(323);
            _subject.AddValue(223);
            _subject.SortValues(Models.SortByEnum.Desc);
            _subject.AddValue(null);
        }

        [TestCase]
        public void ThenNoAdditionalValuesAreAddedToTheList()
        {
            Assert.That(_subject.GetValues().Count, Is.EqualTo(3));
        }

        [TestCase]
        public void ThenTheSortOrderShouldNotBeResetToUnordered()
        {
            Assert.That(_subject.SortBy, Is.Not.EqualTo(Models.SortByEnum.Unordered));
        }
    }
}
