using Data;
using Data.Records;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests.GivenARequestToSaveANewValue
{
    [TestFixture]
    public class WhenTheValueIsValid
    {
        private Mock<ValuesContext> _dbContext;

        [SetUp]
        public void SetUp()
        {
            _dbContext = new Mock<ValuesContext>();
            _dbContext.Setup(context => context.Values.Add(It.IsAny<ValueRecord>()));

            var subject = new ValuesRepository(_dbContext.Object);
            subject.Add(234);
        }

        [TestCase]
        public void ThenTheValueIsAddedToTheContext()
        {
            _dbContext.Verify(context => context.Values.Add(It.Is<ValueRecord>(record => record.Value == 234)), Times.Once());
        }
    }
}
