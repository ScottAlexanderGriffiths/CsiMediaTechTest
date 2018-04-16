using Core.Tests.Mock;
using Core.Types;
using NUnit.Framework;

namespace Core.Tests.Services.GivenARequestToExportTheChangeLog
{
    [TestFixture]
    public class WhenTheChangeLogIsPopulated
    {
        private string _result;

        [SetUp]
        public void SetUp()
        {
            var mockUnitOfWork = new MockUnitOfWork<MockDataContext>();
            var subject = new ValuesService(mockUnitOfWork);
            _result = subject.ExportChangeLog();
        }

        [TestCase]
        public void ThenTheExportedXmlIsCorrect()
        {
            Assert.That(_result, Is.EqualTo("<?xml version=\"1.0\" encoding=\"utf-16\"?><ChangeLog xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Versions><Version><VersionNumber>1</VersionNumber><SortBy>Asc</SortBy><TimeTaken>200</TimeTaken><Values><int>33</int><int>66</int><int>99</int></Values></Version><Version><VersionNumber>2</VersionNumber><SortBy>Desc</SortBy><TimeTaken>180</TimeTaken><Values><int>99</int><int>66</int><int>33</int></Values></Version><Version><VersionNumber>3</VersionNumber><SortBy>Asc</SortBy><TimeTaken>100</TimeTaken><Values><int>33</int><int>66</int><int>99</int></Values></Version></Versions></ChangeLog>"));
        }
    }
}
