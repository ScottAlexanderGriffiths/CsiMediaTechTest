using NUnit.Framework;
using System.Linq;
using Core.Types;
using Core.Tests.Mock;

namespace Core.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenTheValueIsValid
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mockUnitOfWork = new MockUnitOfWork<MockDataContext>();
            _subject = new ValuesService(mockUnitOfWork);
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
            Assert.That(_subject.GetCurrentSortDirection(), Is.EqualTo(SortByEnum.Unordered));
        }

        [TestCase]
        public void ThenThereIsOnlyOneItemInTheList()
        {
            Assert.That(_subject.GetValues().Count(), Is.EqualTo(4));
        }
    }
}
