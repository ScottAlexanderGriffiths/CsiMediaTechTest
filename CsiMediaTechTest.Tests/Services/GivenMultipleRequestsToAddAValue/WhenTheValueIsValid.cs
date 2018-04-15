using CsiMediaTechTest.Services;
using NUnit.Framework;

namespace CsiMediaTechTest.Tests.Services.GivenMultipleRequestsToAddAValue
{
    [TestFixture]
    public class WhenTheValueIsValid
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            _subject = new ValuesService();
            _subject.AddValue(10);
            _subject.AddValue(20);
            _subject.AddValue(30);
        }

        [TestCase]
        public void ThenTheFirstEntryInTheChangelogIsUnaffectedByTheLaterChanges()
        {
            Assert.That(_subject.GetChangeLog()[0].Version, Is.EqualTo(1));
            Assert.That(_subject.GetChangeLog()[0].Values.Count, Is.EqualTo(1));
            Assert.That(_subject.GetChangeLog()[0].Values.Contains(10));
            Assert.That(_subject.GetChangeLog()[0].SortBy, Is.EqualTo(Models.SortByEnum.Unordered));
        }

        [TestCase]
        public void ThenTheSecondEntryInTheChangelogIsUnaffectedByTheLaterChanges()
        {
            Assert.That(_subject.GetChangeLog()[1].Version, Is.EqualTo(2));
            Assert.That(_subject.GetChangeLog()[1].Values.Count, Is.EqualTo(2));
            Assert.That(_subject.GetChangeLog()[1].Values.Contains(10));
            Assert.That(_subject.GetChangeLog()[1].Values.Contains(20));
            Assert.That(_subject.GetChangeLog()[1].SortBy, Is.EqualTo(Models.SortByEnum.Unordered));
        }

        [TestCase]
        public void ThenTheThirdEntryContainsAllTheChanges()
        {
            Assert.That(_subject.GetChangeLog()[2].Version, Is.EqualTo(3));
            Assert.That(_subject.GetChangeLog()[2].Values.Count, Is.EqualTo(3));
            Assert.That(_subject.GetChangeLog()[2].Values.Contains(10));
            Assert.That(_subject.GetChangeLog()[2].Values.Contains(20));
            Assert.That(_subject.GetChangeLog()[2].Values.Contains(30));
            Assert.That(_subject.GetChangeLog()[2].SortBy, Is.EqualTo(Models.SortByEnum.Unordered));
        }
    }
}
