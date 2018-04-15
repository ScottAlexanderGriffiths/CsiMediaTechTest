using NUnit.Framework;
using System.Linq;
using Core.Types;

namespace Core.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenCurrentlySortedAscending
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            _subject = new ValuesService();
            _subject.AddValue(100);
            _subject.AddValue(200);
            _subject.AddValue(300);
            _subject.SortValues(SortByEnum.Asc);
        }

        [TestCase]
        public void ThenTheListIsSortedInDescendingOrder()
        {
            Assert.That(_subject.GetValues()[0], Is.EqualTo(300));
            Assert.That(_subject.GetValues()[1], Is.EqualTo(200));
            Assert.That(_subject.GetValues()[2], Is.EqualTo(100));
        }

        [TestCase]
        public void ThenTheSortByIsSetToDesc()
        {
            Assert.That(_subject.SortBy, Is.EqualTo(SortByEnum.Desc));
        }

        [TestCase]
        public void ThenTheNumberOfItemsInTheListIsUnchanged()
        {
            Assert.That(_subject.GetValues().Count(), Is.EqualTo(3));
        }

        [TestCase]
        public void ThenThereIsANewEntryInTheChangeLog()
        {
            Assert.That(_subject.GetChangeLog().Last().VersionNumber, Is.EqualTo(1));
            Assert.That(_subject.GetChangeLog().Last().Values.Count, Is.EqualTo(3));
            Assert.That(_subject.GetChangeLog().Last().Values.Last(), Is.EqualTo(100));
            Assert.That(_subject.GetChangeLog().Last().SortBy, Is.EqualTo(SortByEnum.Desc));
        }
    }
}
