using NUnit.Framework;
using System.Linq;
using Core.Types;
using Core.Tests.Mock;

namespace Core.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenCurrentlySortedDescending
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mockUnitOfWork = new MockUnitOfWork<MockDataContext>();
            _subject = new ValuesService(mockUnitOfWork);
            _subject.SortValues(SortByEnum.Desc);
        }

        [TestCase]
        public void ThenTheListIsSortedInAscendingOrder()
        {
            Assert.That(_subject.GetValues()[0], Is.EqualTo(33));
            Assert.That(_subject.GetValues()[1], Is.EqualTo(66));
            Assert.That(_subject.GetValues()[2], Is.EqualTo(99));
        }

        [TestCase]
        public void ThenTheSortByIsSetToAsc()
        {
            Assert.That(_subject.GetCurrentSortDirection(), Is.EqualTo(SortByEnum.Asc));
        }

        [TestCase]
        public void ThenTheNumberOfItemsInTheListIsUnchanged()
        {
            Assert.That(_subject.GetValues().Count(), Is.EqualTo(3));
        }

        [TestCase]
        public void ThenThereIsANewEntryInTheChangeLog()
        {
            Assert.That(_subject.GetChangeLog().Versions.Last().VersionNumber, Is.EqualTo(4));
            Assert.That(_subject.GetChangeLog().Versions.Last().Values.Count, Is.EqualTo(3));
            Assert.That(_subject.GetChangeLog().Versions.Last().Values.Last(), Is.EqualTo(99));
            Assert.That(_subject.GetChangeLog().Versions.Last().SortBy, Is.EqualTo(SortByEnum.Asc));
        }
    }
}
