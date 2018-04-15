using NUnit.Framework;
using System.Linq;
using Core.Types;

namespace Core.Tests.Services.GivenARequestToAddAValue
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
            Assert.That(_subject.SortBy, Is.EqualTo(SortByEnum.Unordered));
        }

        [TestCase]
        public void ThenThereIsOnlyOneItemInTheList()
        {
            Assert.That(_subject.GetValues().Count(), Is.EqualTo(1));
        }
    }
}
