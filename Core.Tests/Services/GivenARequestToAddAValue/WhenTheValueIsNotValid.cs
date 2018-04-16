using NUnit.Framework;
using Core.Types;
using Core.Tests.Mock;

namespace Core.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenTheValueIsNotValid
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            var mockUnitOfWork = new MockUnitOfWork<MockDataContext>();
            _subject = new ValuesService(mockUnitOfWork);
            _subject.SortValues(SortByEnum.Asc);
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
            Assert.That(_subject.GetCurrentSortDirection(), Is.Not.EqualTo(SortByEnum.Unordered));
        }
    }
}
