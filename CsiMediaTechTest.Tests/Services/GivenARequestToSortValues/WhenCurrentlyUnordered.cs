﻿using CsiMediaTechTest.Services;
using NUnit.Framework;
using System.Linq;

namespace CsiMediaTechTest.Tests.Services.GivenARequestToAddAValue
{
    [TestFixture]
    public class WhenCurrentlyUnordered
    {
        public ValuesService _subject { get; set; }

        [SetUp]
        public void SetUp()
        {
            _subject = new ValuesService();
            _subject.AddValue(100);
            _subject.AddValue(300);
            _subject.AddValue(200);
            _subject.SortValues(Models.SortByEnum.Unordered);
        }

        [TestCase]
        public void ThenTheListIsSortedInAscendingOrder()
        {
            Assert.That(_subject.GetValues()[0], Is.EqualTo(100));
            Assert.That(_subject.GetValues()[1], Is.EqualTo(200));
            Assert.That(_subject.GetValues()[2], Is.EqualTo(300));
        }

        [TestCase]
        public void ThenTheSortByIsSetToAsc()
        {
            Assert.That(_subject.SortBy, Is.EqualTo(Models.SortByEnum.Asc));
        }

        [TestCase]
        public void ThenTheNumberOfItemsInTheListIsUnchanged()
        {
            Assert.That(_subject.GetValues().Count(), Is.EqualTo(3));
        }
    }
}
